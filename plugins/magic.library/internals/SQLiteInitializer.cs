/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen.
 * See the attached LICENSE file for details. For license inquiries email thomas@ainiro.io
 */
using System;
using System.Threading.Tasks;
using Ainiro.Data.Sqlite;
using System.Runtime.InteropServices;
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
            connection.EnableExtensions();
            var plt = GetPlatformExtension();
            var extensionPath = resolver.RuntimePath("sqlite-plugins/vector" + plt);
            using (var load = connection.CreateCommand())
            {
                load.CommandText = "select load_extension($p, 'sqlite3_vector_init')";
                load.Parameters.AddWithValue("$p", extensionPath);
                _ = await load.ExecuteScalarAsync();
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
    }
}
