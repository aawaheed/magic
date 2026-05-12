/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.io.signatures
{
    /// <summary>
    /// Child signature for slots that consume one evaluated child value.
    /// </summary>
    public abstract class SingleContentSignature : ISlotSignature
    {
        readonly string _type;
        readonly string _description;

        /// <summary>
        /// Creates a child signature for one content node.
        /// </summary>
        /// <param name="type">Documented content type.</param>
        /// <param name="description">Documented content description.</param>
        protected SingleContentSignature(string type, string description)
        {
            _type = type;
            _description = description;
        }

        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = _type,
                Kind = _description.Contains("Destination path") ? "path" : null,
                Description = _description,
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyOne,
            },
        };
    }

    /// <summary>
    /// Child signature for text file save slots.
    /// </summary>
    public class TextFileSaveSignature : SingleContentSignature
    {
        /// <summary>
        /// Creates an instance of the signature.
        /// </summary>
        public TextFileSaveSignature()
            : base("string", "Child node yielding the text content to save")
        { }
    }

    /// <summary>
    /// Child signature for binary file save slots.
    /// </summary>
    public class BinaryFileSaveSignature : SingleContentSignature
    {
        /// <summary>
        /// Creates an instance of the signature.
        /// </summary>
        public BinaryFileSaveSignature()
            : base("byte[]", "Child node yielding the binary content to save")
        { }
    }

    /// <summary>
    /// Child signature for file and folder copy/move slots.
    /// </summary>
    public class CopyMoveSignature : SingleContentSignature
    {
        /// <summary>
        /// Creates an instance of the signature.
        /// </summary>
        public CopyMoveSignature()
            : base("string", "Destination path")
        { }
    }

    /// <summary>
    /// Child signature for file and folder list slots.
    /// </summary>
    public class ListDirectorySignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "display-hidden",
                Type = "bool",
                Description = "Whether hidden files or folders should be included",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
            new SlotChild
            {
                Name = "display-system",
                Type = "bool",
                Description = "Whether system folders such as /system/, /misc/, /data/, and /config/ should be included",
                Required = false,
                DefaultValue = "true",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
        };
    }

    /// <summary>
    /// Child signature for patch file slot.
    /// </summary>
    public class PatchFileSignature : SingleContentSignature
    {
        /// <summary>
        /// Creates an instance of the signature.
        /// </summary>
        public PatchFileSignature()
            : base("string", "Unified diff patch content to apply")
        { }
    }

    /// <summary>
    /// Child signature for file execution slots.
    /// </summary>
    public class ExecuteFileSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Named argument passed to the executed file as a child of [.arguments]",
                Required = false,
                Mode = SlotChildMode.Arguments,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
            },
        };
    }

    /// <summary>
    /// Child signature for [execute-file], which unwraps argument expressions first.
    /// </summary>
    public class ExecuteFileUnwrapSignature : ExecuteFileSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Named argument passed to the executed file as a child of [.arguments]",
                Required = false,
                Mode = SlotChildMode.Arguments,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Preprocess = SlotChildPreprocess.UnwrapExpressions,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
            },
        };
    }

    /// <summary>
    /// Child signature for file search slot.
    /// </summary>
    public class SearchFileSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "pattern",
                Type = "string",
                Kind = "search-pattern",
                Description = "Text or regular expression pattern to search for",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ExactlyOne,
            },
            new SlotChild
            {
                Name = "regex",
                Type = "bool",
                Description = "Whether [pattern] should be interpreted as a regular expression",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
            new SlotChild
            {
                Name = "case-sensitive",
                Type = "bool",
                Description = "Whether matching should be case-sensitive",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
            new SlotChild
            {
                Name = "extensions",
                Type = "string",
                Kind = "file-extension-list",
                Description = "Optional comma-separated file extensions to include",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
        };
    }

    /// <summary>
    /// Child signature for unzip slot.
    /// </summary>
    public class UnzipFileSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "folder",
                Type = "string",
                Kind = "folder-path",
                Description = "Destination folder; defaults to the zip file's folder",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
            new SlotChild
            {
                Name = "overwrite",
                Type = "bool",
                Description = "Whether existing extracted files should be overwritten",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
        };
    }

    /// <summary>
    /// Child signature for creating ZIP streams from supplied entries.
    /// </summary>
    public class ZipContentSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "string",
                Kind = "zip-entry-path",
                Description = "ZIP entry path",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string|byte[]",
                        Kind = "zip-entry-content",
                        Description = "Entry content",
                        Required = true,
                        Mode = SlotChildMode.ExecutableLambda,
                        Cardinality = SlotChildCardinality.ExactlyOne,
                    },
                },
            },
        };
    }

    /// <summary>
    /// Child signature for saving streams to files.
    /// </summary>
    public class SaveStreamToFileSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "overwrite",
                Type = "bool",
                Description = "Whether an existing file should be overwritten",
                Required = false,
                DefaultValue = "true",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            },
            new SlotChild
            {
                Name = "*",
                Type = "Stream",
                Description = "Child node yielding the stream to save",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyOne,
            },
        };
    }

    /// <summary>
    /// Child signature for [io.file.mixin].
    /// </summary>
    public class FileMixinSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Optional argument available to codebehind lambda loaded for the mixed file",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
            },
        };
    }
}
