/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.misc
{
    /// <summary>
    /// [types] slot returning all supported Hyperlambda types.
    /// </summary>
    [Slot(
        Name = "types",
        Description = "Lists every CLR type name recognized by Hyperlambda; useful when [convert] or [type] needs a valid target",
        ReturnsMode = SlotReturnsMode.Lambda,
        ReturnsType = "lambda",
        // Multi-tag chain, specific → structural: `string-list` (each child
        // value is a string) and `node-list` (topology) were both missing,
        // leaving the chain undertagged. Consumers asking for "list of
        // strings" or generic "list of nodes" must kind-match.
        ReturnsKind = "type-name-list,string-list",
        ReturnsElementType = "string",
        ReturnsElementKind = "type-name,text",
        ReturnsDescription = "Resolves to one child node per known CLR type name")]
    public class Types : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.AddRange(Converter.GetTypes().Select(x => new Node("", x)));
        }
    }
}
