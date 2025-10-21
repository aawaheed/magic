/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Threading.Tasks;
using Ainiro.Data.Sqlite;
using magic.node.contracts;

namespace magic.lambda.sqlite
{
    /// <summary>
    /// Interface for initializing database connection. Useful for loading plugins and such.
    /// </summary>
    public interface IInitializer
    {
        /// <summary>
        /// Initializes the database, invoked every single time you create a new database connection.
        /// </summary>
        /// <param name="resolver">Required to resolve absolute paths</param>
        /// <param name="connection">Recently created SQLite database connection</param>
        Task Initialize(IRootResolver resolver, SqliteConnection connection);
    }
}
