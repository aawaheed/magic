/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */

using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using magic.lambda.sqlite;
using magic.node.contracts;
using System.Runtime.InteropServices;

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
            using (var load = connection.CreateCommand())
            {
                var plt = "";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    plt = ".dll";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    plt = ".so";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    plt = ".dylib";
                load.CommandText = "select load_extension($p, 'sqlite3_vector_init')";
                load.Parameters.AddWithValue("$p", resolver.RuntimePath("sqlite-plugins/vector" + plt));
                _ = await load.ExecuteScalarAsync();
            }
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "select vector_init($tbl, $col, $opts);";
                cmd.Parameters.AddWithValue("$tbl", TableName);
                cmd.Parameters.AddWithValue("$col", ColumnName);
                cmd.Parameters.AddWithValue("$opts", Options);
                _ = await cmd.ExecuteScalarAsync();
            }
        }
    }
}
