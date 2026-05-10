/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.data.common.helpers;
using magic.lambda.sqlite.helpers;

namespace magic.lambda.sqlite
{
    /// <summary>
    /// [sqlite.backup] slot for backing up the current SQLite connection.
    /// </summary>
    [Slot(
        Name = "sqlite.backup",
        Description = "Creates a backup of the current SQLite connection",
        ValueType = "string",
        ValueDescription = "Target SQLite database filename under files/data/",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.None)]
    public class Backup : ISlotAsync
    {
        /// <summary>
        /// Handles the signal for the class.
        /// </summary>
        /// <param name="signaler">Signaler used to signal the slot.</param>
        /// <param name="input">Root node for invocation.</param>
        /// <returns>An awaitable task.</returns>
        public Task SignalAsync(ISignaler signaler, Node input)
        {
            using (var shutdownLock = new ShutdownLock())
            {
                var source = signaler.Peek<SqliteConnectionWrapper>("sqlite.connect").Connection;
                var name = input.GetEx<string>();
                using (var destination = new SqliteConnection(string.Format(@"Data Source=files/data/{0};", name)))
                {
                    source.BackupDatabase(destination);
                    return Task.CompletedTask;
                }
            }
        }
    }
}
