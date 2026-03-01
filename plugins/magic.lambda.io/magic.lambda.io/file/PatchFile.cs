/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.contracts;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.io.file
{
    /// <summary>
    /// [io.file.patch] slot for patching a file on your server using a unified diff patch.
    /// </summary>
    [Slot(Name = "io.file.patch")]
    public class PatchFile : ISlotAsync
    {
        readonly IRootResolver _rootResolver;
        readonly IFileService _service;

        /// <summary>
        /// Constructs a new instance of your type.
        /// </summary>
        /// <param name="rootResolver">Instance used to resolve the root folder of your app.</param>
        /// <param name="service">Underlaying file service implementation.</param>
        public PatchFile(IRootResolver rootResolver, IFileService service)
        {
            _rootResolver = rootResolver;
            _service = service;
        }

        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to slot.</param>
        /// <returns>An awaitable task.</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            // Making sure we evaluate any children, to make sure any signals wanting to retrieve our source is evaluated.
            await signaler.SignalAsync("eval", input);

            // Retrieving arguments.
            var path = _rootResolver.AbsolutePath(input.GetEx<string>());
            var patch = input.Children.First().GetEx<string>();

            // Enforcing that the patch applies to a single file only.
            EnsureSingleFilePatch(patch);

            // Loading original file content.
            var original = await _service.LoadAsync(path);

            // Applying patch and saving file.
            var patched = ApplyUnifiedDiff(original, patch);
            await _service.SaveAsync(path, patched);
        }

        #region [ -- Private helper methods -- ]

        /*
         * Ensures the patch does not attempt to modify multiple files.
         */
        static void EnsureSingleFilePatch(string patch)
        {
            var lines = SplitLines(patch);
            var headerCount = 0;
            for (var i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("--- ", StringComparison.InvariantCulture) &&
                    i + 1 < lines.Count &&
                    lines[i + 1].StartsWith("+++ ", StringComparison.InvariantCulture))
                {
                    headerCount++;
                }
            }

            if (headerCount > 1)
                throw new HyperlambdaException("Patch can only modify a single file.");
        }

        /*
         * Applies a unified diff patch to the specified content.
         */
        static string ApplyUnifiedDiff(string original, string patch)
        {
            var newline = original.Contains("\r\n", StringComparison.InvariantCulture) ? "\r\n" : "\n";
            var originalLines = SplitLines(original);
            var patchLines = SplitLines(patch);
            var output = new List<string>();

            var originalIndex = 0;
            var patchIndex = 0;

            while (patchIndex < patchLines.Count)
            {
                var line = patchLines[patchIndex];

                if (line.StartsWith("diff --git", StringComparison.InvariantCulture) ||
                    line.StartsWith("index ", StringComparison.InvariantCulture) ||
                    line.StartsWith("--- ", StringComparison.InvariantCulture) ||
                    line.StartsWith("+++ ", StringComparison.InvariantCulture))
                {
                    patchIndex++;
                    continue;
                }

                if (!line.StartsWith("@@", StringComparison.InvariantCulture))
                {
                    patchIndex++;
                    continue;
                }

                var (oldStart, _, _) = ParseHunkHeader(line);
                var targetIndex = oldStart - 1;

                // Copy unchanged lines before hunk.
                while (originalIndex < targetIndex && originalIndex < originalLines.Count)
                {
                    output.Add(originalLines[originalIndex]);
                    originalIndex++;
                }

                patchIndex++;
                while (patchIndex < patchLines.Count)
                {
                    line = patchLines[patchIndex];
                    if (line.StartsWith("@@", StringComparison.InvariantCulture))
                        break;

                    if (line.Length == 0)
                    {
                        // Treat empty line as a context line.
                        EnsureLineMatch(originalLines, originalIndex, string.Empty);
                        output.Add(originalLines[originalIndex]);
                        originalIndex++;
                        patchIndex++;
                        continue;
                    }

                    var tag = line[0];
                    var text = line.Length > 1 ? line.Substring(1) : string.Empty;
                    switch (tag)
                    {
                        case ' ':
                            EnsureLineMatch(originalLines, originalIndex, text);
                            output.Add(originalLines[originalIndex]);
                            originalIndex++;
                            break;

                        case '-':
                            EnsureLineMatch(originalLines, originalIndex, text);
                            originalIndex++;
                            break;

                        case '+':
                            output.Add(text);
                            break;

                        case '\\':
                            // "\ No newline at end of file" - ignore.
                            break;

                        default:
                            throw new HyperlambdaException("Invalid patch line.");
                    }

                    patchIndex++;
                }

                // We intentionally do not enforce hunk line counts to allow standard diffs with extra context.
            }

            // Append remaining original lines.
            while (originalIndex < originalLines.Count)
            {
                output.Add(originalLines[originalIndex]);
                originalIndex++;
            }

            return string.Join(newline, output);
        }

        /*
         * Parses a unified diff hunk header.
         */
        static (int OldStart, int OldCount, int NewStart) ParseHunkHeader(string header)
        {
            // Format: @@ -l,s +l,s @@
            var parts = header.Split(' ');
            if (parts.Length < 3)
                throw new HyperlambdaException("Invalid hunk header.");

            var oldPart = parts[1];
            var newPart = parts[2];

            if (!oldPart.StartsWith("-", StringComparison.InvariantCulture) ||
                !newPart.StartsWith("+", StringComparison.InvariantCulture))
                throw new HyperlambdaException("Invalid hunk header.");

            var (oldStart, oldCount) = ParseRange(oldPart.Substring(1));
            var (newStart, _) = ParseRange(newPart.Substring(1));
            return (oldStart, oldCount, newStart);
        }

        /*
         * Parses a line range from a hunk header.
         */
        static (int Start, int Count) ParseRange(string range)
        {
            var parts = range.Split(',');
            if (parts.Length == 1)
                return (ParseInt(parts[0]), 1);

            return (ParseInt(parts[0]), ParseInt(parts[1]));
        }

        /*
         * Parses an integer invariantly.
         */
        static int ParseInt(string value)
        {
            if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                throw new HyperlambdaException("Invalid hunk header.");
            return result;
        }

        /*
         * Ensures the current original line matches the expected line.
         */
        static void EnsureLineMatch(IReadOnlyList<string> originalLines, int index, string expected)
        {
            if (index >= originalLines.Count || !string.Equals(originalLines[index], expected, StringComparison.InvariantCulture))
                throw new HyperlambdaException("Patch could not be applied.");
        }

        /*
         * Splits text into lines, preserving empty lines.
         */
        static List<string> SplitLines(string text)
        {
            return text
                .Replace("\r\n", "\n")
                .Split(new[] { '\n' }, StringSplitOptions.None)
                .ToList();
        }

        #endregion
    }
}
