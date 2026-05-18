/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using System.Linq;
using System.Collections.Generic;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.misc
{
    /// <summary>
    /// [apply] slot allowing you to use a lambda as a template for braiding together
    /// with variables of your own choosing.
    /// </summary>
    [Slot(
        Name = "apply",
        Description = "Stamps a template lambda with values from child argument nodes, producing one fully-substituted output per [.dp]",
        ValueType = "expression",
        // `template,lambda-tree` — multi-tag: semantic identity first (a
        // template lambda carrying `{name}` placeholders), then the
        // structural lambda-tree shape. The earlier `lambda` tag was the
        // .NET TYPE name leaked into the kind chain — redundant with
        // `ValueType=lambda` and not a kind at all. Removed.
        ValueKind = "template,lambda-tree",
        ValueDescription = "Expression selecting the template node or nodes to transform",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Lambda,
        ReturnsType = "lambda",
        // `applied-template,lambda-object,lambda-tree` — semantic chain:
        // an applied template IS executable code (`lambda-object` —
        // narrowest), which IS a lambda tree (structural parent). This
        // marks `[apply]`'s output as a valid producer for `[invoke]`/
        // `[eval]` which consume `lambda-object`.
        ReturnsKind = "applied-template,lambda-object,lambda-tree",
        ReturnsDescription = "Resolves to the transformed template nodes after applying the supplied arguments",
        SignatureType = typeof(global::magic.lambda.signatures.ApplySignature))]
    public class Apply : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var args = input.Children.ToList();
            input.Clear();
            foreach (var idxDest in input.Evaluate())
            {
                var destination = idxDest.Clone();
                Transform(args, destination.Children);

                // Returning transformed template to caller.
                input.AddRange(destination.Children.ToList());
            }
            input.Value = null;
        }

        #region [ -- Private helper methods -- ]

        /*
         * Actual implementation that applies lambda object to destination.
         */
        void Transform(IEnumerable<Node> args, IEnumerable<Node> templateNodes)
        {
            foreach (var idx in templateNodes)
            {
                if (idx.Value is string strValue &&
                    strValue.StartsWith("{", StringComparison.InvariantCulture) &&
                    strValue.EndsWith("}", StringComparison.InvariantCulture))
                {
                    // Template variable, finding relevant node from args and applying
                    var templateName = strValue.Substring(1, strValue.Length - 2);
                    var argNode = args.FirstOrDefault(x => x.Name == templateName);
                    if (argNode == null)
                        throw new HyperlambdaException($"[template] file expected argument named [{templateName}] which was not given");

                    idx.Value = argNode.Value;
                    idx.AddRange(argNode.Children.Select(x => x.Clone()));
                }
                if (idx.Name.StartsWith("{", StringComparison.InvariantCulture) &&
                    idx.Name.EndsWith("}", StringComparison.InvariantCulture))
                {
                    var templateName = idx.Name.Substring(1, idx.Name.Length - 2);
                    var argNode = args.FirstOrDefault(x => x.Name == templateName);
                    if (argNode == null)
                        throw new HyperlambdaException($"[template] file expected argument named [{templateName}] which was not given");

                    idx.Name = argNode.Get<string>();
                    idx.AddRange(argNode.Children.Select(x => x.Clone()));
                }

                // Recursively invoking self
                Transform(args, idx.Children);
            }
        }

        #endregion
    }
}
