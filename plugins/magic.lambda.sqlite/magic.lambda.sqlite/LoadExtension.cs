/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.lambda.sqlite.helpers;
using System.Threading;

namespace magic.lambda.sqlite
{
    /// <summary>
    /// [sqlite.load-extension] slot for loading SQLite extensions.
    /// </summary>
    [Slot(Name = "sqlite.load-extension")]
    public class LoadExtension : ISlotAsync
    {
        // Ensuring synchronized access.
        readonly static SemaphoreSlim _semaphore = new (1,1);

        /// <summary>
        /// Handles the signal for the class.
        /// </summary>
        /// <param name="signaler">Signaler used to signal the slot.</param>
        /// <param name="input">Root node for invocation.</param>
        /// <returns>An awaitable task.</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            await _semaphore.WaitAsync();
            try
            {
                var connection = signaler.Peek<SqliteConnectionWrapper>("sqlite.connect").Connection;
                connection.LoadExtension(
                    input.Children.FirstOrDefault(x => x.Name == "file")?.GetEx<string>() ?? 
                        throw new HyperlambdaException("No [file] argument provided to [sqlite.load-extension]"),
                    input.Children.FirstOrDefault(x => x.Name == "proc")?.GetEx<string>() ?? 
                        throw new HyperlambdaException("No [proc] argument provided to [sqlite.load-extension]"));
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
