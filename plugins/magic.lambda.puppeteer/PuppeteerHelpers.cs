/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;
using PuppeteerSharp.Input;

namespace magic.lambda.puppeteer
{
    internal static class PuppeteerHelpers
    {
        public static IBrowser RequireBrowser(ISignaler signaler)
        {
            var browser = signaler.Peek<IBrowser>("puppeteer.browser");
            if (browser == null)
                throw new HyperlambdaException("[puppeteer.connect] must scope a browser before invoking Puppeteer slots");
            return browser;
        }

        public static IPage RequirePage(ISignaler signaler)
        {
            var page = signaler.Peek<IPage>("puppeteer.page");
            if (page == null)
                throw new HyperlambdaException("[puppeteer.page] must scope a page before invoking Puppeteer slots");
            return page;
        }

        public static Node GetLambda(Node input)
        {
            var lambda = input.Children.FirstOrDefault(x => x.Name == ".lambda");
            return lambda ?? input;
        }

        public static bool HasAnyChild(Node input, params string[] names)
        {
            if (names == null || names.Length == 0)
                return false;

            return input.Children.Any(x => names.Contains(x.Name));
        }

        public static string GetRequiredValue(Node input, string label)
        {
            var value = input.GetEx<string>();
            if (string.IsNullOrWhiteSpace(value))
                throw new HyperlambdaException($"[{label}] requires a non-empty value");
            return value;
        }

        public static string GetOptionalString(Node input, string name)
        {
            return input.Children.FirstOrDefault(x => x.Name == name)?.GetEx<string>();
        }

        public static bool? GetOptionalBool(Node input, string name)
        {
            var node = input.Children.FirstOrDefault(x => x.Name == name);
            return node == null ? null : node.GetEx<bool>();
        }

        public static int? GetOptionalInt(Node input, string name)
        {
            var node = input.Children.FirstOrDefault(x => x.Name == name);
            return node == null ? null : node.GetEx<int>();
        }

        public static IEnumerable<string> GetArgs(Node argsNode)
        {
            if (argsNode == null)
                yield break;

            if (argsNode.Children.Any())
            {
                foreach (var child in argsNode.Children)
                {
                    var value = child.GetEx<string>();
                    if (!string.IsNullOrWhiteSpace(value))
                        yield return value;
                }
                yield break;
            }

            var argsText = argsNode.GetEx<string>();
            if (string.IsNullOrWhiteSpace(argsText))
                yield break;

            foreach (var arg in SplitArgs(argsText))
                yield return arg;
        }

        public static string[] GetValues(Node valuesNode)
        {
            if (valuesNode == null)
                return Array.Empty<string>();

            if (valuesNode.Children.Any())
                return valuesNode.Children.Select(x => x.GetEx<string>()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            var text = valuesNode.GetEx<string>();
            if (string.IsNullOrWhiteSpace(text))
                return Array.Empty<string>();

            return text.Split(',').Select(x => x.Trim()).Where(x => x.Length > 0).ToArray();
        }

        public static WaitUntilNavigation? ParseWaitUntil(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            switch (value.Trim().ToLowerInvariant())
            {
                case "load":
                    return WaitUntilNavigation.Load;
                case "domcontentloaded":
                    return WaitUntilNavigation.DOMContentLoaded;
                case "networkidle0":
                    return WaitUntilNavigation.Networkidle0;
                case "networkidle2":
                    return WaitUntilNavigation.Networkidle2;
                default:
                    throw new HyperlambdaException($"Unsupported wait-until value '{value}'");
            }
        }

        public static MouseButton ParseMouseButton(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return MouseButton.Left;

            switch (value.Trim().ToLowerInvariant())
            {
                case "left":
                    return MouseButton.Left;
                case "middle":
                    return MouseButton.Middle;
                case "right":
                    return MouseButton.Right;
                default:
                    throw new HyperlambdaException($"Unsupported mouse button '{value}'");
            }
        }

        static IEnumerable<string> SplitArgs(string input)
        {
            var args = new List<string>();
            var current = new StringBuilder();
            var inQuotes = false;
            var quoteChar = '\0';

            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];

                if (inQuotes)
                {
                    if (c == quoteChar)
                    {
                        inQuotes = false;
                    }
                    else if (c == '\\' && i + 1 < input.Length && input[i + 1] == quoteChar)
                    {
                        current.Append(quoteChar);
                        i++;
                    }
                    else
                    {
                        current.Append(c);
                    }
                    continue;
                }

                if (char.IsWhiteSpace(c))
                {
                    if (current.Length > 0)
                    {
                        args.Add(current.ToString());
                        current.Clear();
                    }
                    continue;
                }

                if (c == '"' || c == '\'')
                {
                    inQuotes = true;
                    quoteChar = c;
                    continue;
                }

                current.Append(c);
            }

            if (current.Length > 0)
                args.Add(current.ToString());

            return args;
        }
    }
}
