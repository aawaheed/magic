/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Threading.Tasks;
using magic.node;
using magic.signals.contracts;
using magic.data.common.helpers;
using magic.lambda.sqlite.helpers;
using magic.node.extensions;
using System.Linq;

namespace magic.lambda.sqlite
{
    /// <summary>
    /// [sqlite.load-extension] slot for loading SQLite extensions.
    /// </summary>
    [Slot(Name = "sqlite.load-extension")]
    public class LoadExtension : ISlotAsync
    {
        /// <summary>
        /// Handles the signal for the class.
        /// </summary>
        /// <param name="signaler">Signaler used to signal the slot.</param>
        /// <param name="input">Root node for invocation.</param>
        /// <returns>An awaitable task.</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var connection = signaler.Peek<SqliteConnectionWrapper>("sqlite.connect").Connection;
            connection.LoadExtension(
                input.Children.FirstOrDefault(x => x.Name == "file")?.GetEx<string>() ?? 
                    throw new HyperlambdaException("No [file] argument provided to [sqlite.load-extension]"),
                input.Children.FirstOrDefault(x => x.Name == "proc")?.GetEx<string>() ?? 
                    throw new HyperlambdaException("No [proc] argument provided to [sqlite.load-extension]")
            );
        }
    }
}
