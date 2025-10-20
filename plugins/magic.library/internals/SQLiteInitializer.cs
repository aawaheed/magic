/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */

using System.Data;
using System.Threading.Tasks;
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
            // Ensure the connection is open
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            // Enable and load the extension for THIS connection (per-connection in SQLite)
            connection.EnableExtensions();
            connection.LoadExtension(resolver.RuntimePath("sqlite-plugins/vector"));

            // Always run vector_init on this connection
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT vector_init($tbl, $col, $opts);";
            cmd.Parameters.AddWithValue("$tbl",  TableName);
            cmd.Parameters.AddWithValue("$col",  ColumnName);
            cmd.Parameters.AddWithValue("$opts", Options);

            // We don't care about the result payload; just ensure it runs.
            // ExecuteScalar will step the statement and read the first row/col.
            _ = await cmd.ExecuteScalarAsync();
        }
    }
}
