/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */
using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using magic.lambda.sqlite;
using magic.node.contracts;

namespace magic.library.internals
{
    /// <summary>
    /// Ensures each SqliteConnection can use sqlite-vector and initializes the target column.
    /// </summary>
    internal class SQLiteInitializer : IInitializer
    {
        private const string TableName  = "ml_training_snippets";
        private const string ColumnName = "embeddings";
        private const string Options    = "dimension=1536,type=FLOAT32,distance=cosine";

        public async Task Initialize(IRootResolver resolver, SqliteConnection connection)
        {
            await connection.OpenAsync();
            connection.EnableExtensions(); // no round-trip

            var plt = GetPlatformExtension();
            var extensionPath = resolver.RuntimePath("sqlite-plugins/vector" + plt);

            try
            {
                await RunVectorInit(connection);
                return;
            }
            catch (SqliteException ex) when (IsNoSuchFunctionVectorInit(ex))
            {
                await LoadVectorExtensionWithRetry(connection, extensionPath);
                await RunVectorInit(connection);
            }
        }

        private static async Task RunVectorInit(SqliteConnection connection)
        {
            // Optional: serialize to avoid two concurrent initializations racing each other.
            await using var tx = await connection.BeginTransactionAsync();

            using (var cmd = connection.CreateCommand())
            {
                cmd.Transaction = (SqliteTransaction)tx;
                cmd.CommandText = "select vector_init($tbl, $col, $opts);";
                cmd.Parameters.AddWithValue("$tbl",  TableName);
                cmd.Parameters.AddWithValue("$col",  ColumnName);
                cmd.Parameters.AddWithValue("$opts", Options);
                _ = await cmd.ExecuteScalarAsync();
            }

            await tx.CommitAsync();
        }

        private static async Task LoadVectorExtensionWithRetry(SqliteConnection connection, string extensionPath)
        {
            var retries = 2;
            while (true)
            {
                try
                {
                    using var load = connection.CreateCommand();
                    load.CommandText = "select load_extension($p, 'sqlite3_vector_init')";
                    load.Parameters.AddWithValue("$p", extensionPath);
                    _ = await load.ExecuteScalarAsync();
                    return;
                }
                catch (SqliteException ex) when (retries > 0 && ex.SqliteErrorCode == 1)
                {
                    retries--;
                    await Task.Delay(80 * (2 - retries)); // 0ms,80ms backoff
                    continue;
                }
            }
        }

        private static bool IsNoSuchFunctionVectorInit(SqliteException ex) =>
            ex.SqliteErrorCode == 1 /* SQLITE_ERROR */ &&
            ex.Message?.IndexOf("no such function: vector_init", StringComparison.OrdinalIgnoreCase) >= 0;

        private static string GetPlatformExtension()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return ".dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))   return ".so";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))     return ".dylib";
            throw new NotSupportedException("Unsupported platform");
        }
    }
}
