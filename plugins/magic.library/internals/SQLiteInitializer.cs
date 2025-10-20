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
    /// Ensures that every new SqliteConnection loads the vector extension
    /// and runs vector_init for ml_training_snippets.embeddings.
    /// </summary>
    internal class SQLiteInitializer : IInitializer
    {
        private const string TableName  = "ml_training_snippets";
        private const string ColumnName = "embeddings";
        private const string Options    = "dimension=1536,type=FLOAT32,distance=cosine";

        public async Task Initialize(IRootResolver resolver, SqliteConnection connection)
        {
            await connection.OpenAsync();
            connection.EnableExtensions();

            var plt = GetPlatformExtension();
            var extensionPath = resolver.RuntimePath("sqlite-plugins/vector" + plt);

            int retries = 3;
            while (retries > 0)
            {
                try
                {
                    using (var load = connection.CreateCommand())
                    {
                        load.CommandText = "select load_extension($p, 'sqlite3_vector_init')";
                        load.Parameters.AddWithValue("$p", extensionPath);
                        await load.ExecuteScalarAsync();
                    }
                    break;
                }
                catch (SqliteException ex) when (retries > 1 && ex.SqliteErrorCode == 1)
                {
                    retries--;
                    await Task.Delay(100 * (4 - retries));
                }
            }

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "select vector_init($tbl, $col, $opts);";
                cmd.Parameters.AddWithValue("$tbl", TableName);
                cmd.Parameters.AddWithValue("$col", ColumnName);
                cmd.Parameters.AddWithValue("$opts", Options);
                await cmd.ExecuteScalarAsync();
            }
        }

        private static string GetPlatformExtension()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ".dll";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ".so";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ".dylib";
            throw new NotSupportedException("Unsupported platform");
        }
    }
}
