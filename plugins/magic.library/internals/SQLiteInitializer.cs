/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using magic.lambda.sqlite;
using magic.node.contracts;

namespace magic.library.internals
{
    /*
     * Internal helper class to help wire up plugins for SQLite.
     */
    internal class SQLiteInitializer : IInitializer
    {
        private static readonly SemaphoreSlim _lock = new(1, 1);

        public async Task Initialize(IRootResolver resolver, SqliteConnection connection)
        {
            await connection.OpenAsync();
            await EnsureVectorLoadedAsync(resolver, connection);
        }

        /*
         * Ensures serialized initialization of vector lib.
         */
        private static async Task EnsureVectorLoadedAsync(IRootResolver resolver, SqliteConnection connection)
        {
            await _lock.WaitAsync();
            try
      {
                connection.EnableExtensions();
                connection.LoadExtension(resolver.RuntimePath("sqlite-plugins/vector"));
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}