/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Runtime.InteropServices;
using magic.node;
using magic.lambda.sqlite;
using magic.node.contracts;
using magic.signals.contracts;

namespace magic.library.internals
{
    /// <summary>
    /// Ensures each SqliteConnection can use sqlite-vector and initializes the target column.
    /// </summary>
    [Slot(Name = "sqlite.init_vector")]
    internal class SQLiteInitializer : IInitializer, ISlot
    {
        const string TableName  = "ml_training_snippets";
        const string ColumnName = "embeddings";
        const string Options    = "dimension=1536,type=FLOAT32,distance=cosine";
        static bool _shouldRunVectorInit = false;
        static readonly SemaphoreSlim _locker = new(1, 1);

        public async Task Initialize(IRootResolver resolver, SqliteConnection connection)
        {
            await _locker.WaitAsync();
            try
            {
                await connection.OpenAsync();
                connection.EnableExtensions();

                var plt = GetPlatformExtension();
                var extensionPath = resolver.RuntimePath("sqlite-plugins/vector" + plt);

                // Notice, we cannot run vector_init before we've created our magic database!!
                if (_shouldRunVectorInit)
                {
                    const int maxAttempts = 3;
                    int attempt = 0;
                    while (true)
                    {
                        try
                        {
                            // Load the extension ONCE per connection (no retries for load).
                            using (var load = connection.CreateCommand())
                            {
                                load.CommandText = "select load_extension($p, 'sqlite3_vector_init')";
                                load.Parameters.AddWithValue("$p", extensionPath);
                                _ = await load.ExecuteScalarAsync();
                            }
                            await RunVectorInit(connection);
                            break;
                        }
                        catch (SqliteException ex) when (IsNoSuchFunctionVectorInit(ex) && ++attempt < maxAttempts)
                        {
                            await Task.Delay(50 * attempt);
                        }
                    }
                }
            }
            finally
            {
                _locker.Release();
            }
        }
        
        /*
         * Private helper methods.
         */

        static async Task RunVectorInit(SqliteConnection connection)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "select vector_init($tbl, $col, $opts);";
                cmd.Parameters.AddWithValue("$tbl",  TableName);
                cmd.Parameters.AddWithValue("$col",  ColumnName);
                cmd.Parameters.AddWithValue("$opts", Options);
                _ = await cmd.ExecuteScalarAsync();
            }
        }

        static bool IsNoSuchFunctionVectorInit(SqliteException ex) =>
            ex.SqliteErrorCode == 1 /* SQLITE_ERROR */ &&
            ex.Message?.IndexOf("no such function: vector_init", StringComparison.OrdinalIgnoreCase) >= 0;

        static string GetPlatformExtension()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return ".dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))   return ".so";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))     return ".dylib";
            throw new NotSupportedException("Unsupported platform");
        }

        // Turning this on (emit the slot) enables the init to run.
        public void Signal(ISignaler signaler, Node input)
        {
            _shouldRunVectorInit = true;
        }
    }
}
