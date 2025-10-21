/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using magic.lambda.sqlite;
using magic.node.contracts;

namespace magic.library.internals
{
    /// <summary>
    /// Ensures each SqliteConnection can use sqlite-vector.
    /// </summary>
    internal class SQLiteInitializer : IInitializer
    {
        public async Task Initialize(IRootResolver resolver, SqliteConnection connection)
        {
            await connection.OpenAsync();
            connection.LoadExtension("sqlite-plugins/vector", "sqlite3_vector_init");
        }
    }
}
