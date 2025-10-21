/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Ainiro.Data.Sqlite;
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

                // Notice, we cannot run vector_init before we've created our magic database!
                if (_shouldRunVectorInit)
                {
                    var plt = GetPlatformExtension();
                    var extensionPath = resolver.RuntimePath("sqlite-plugins/vector" + plt);

                    // Load the extension ONCE per connection (no retries for load).
                    using (var load = connection.CreateCommand())
                    {
                        load.CommandText = "select load_extension($p, 'sqlite3_vector_init')";
                        load.Parameters.AddWithValue("$p", extensionPath);
                        _ = await load.ExecuteScalarAsync();
                    }
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "select vector_init($tbl, $col, $opts);";
                        cmd.Parameters.AddWithValue("$tbl",  TableName);
                        cmd.Parameters.AddWithValue("$col",  ColumnName);
                        cmd.Parameters.AddWithValue("$opts", Options);
                        _ = await cmd.ExecuteScalarAsync();
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
