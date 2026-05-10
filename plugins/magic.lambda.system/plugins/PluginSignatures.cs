/*
 * Magic Cloud, copyright AINIRO, Ltd and Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.system.plugins.signatures
{
    public class CompileSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            Option("code", "string", "C# source code to compile", true),
            Option("assembly-name", "string", "Name of the generated assembly", true),
            new SlotChild
            {
                Name = "references",
                Type = "lambda",
                Description = "Assembly references required by the compilation",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.Children,
                Children =
                {
                    new SlotChild
                    {
                        Name = ".",
                        Type = "string",
                        Description = "Assembly reference",
                        Required = true,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.OneOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            },
        };

        static SlotChild Option(string name, string type, string description, bool required)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    public class ExecutePluginSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Executable body evaluated while the plugin is loaded",
                Required = false,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
            },
        };
    }
}
