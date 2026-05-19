/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using CsvHelper;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.csv
{
    /// <summary>
    /// [csv2lambda] slot for transforming from CSV to a lambda object.
    /// </summary>
    // 'text' pruned: this slot needs CSV syntax, not arbitrary text.
    [Slot(
        Name = "csv2lambda",
        Description = "Transforms CSV into a lambda hierarchy",
        ValueKind = "csv",
        ValueDescription = "CSV text to transform",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ValueExpressionResolution = SlotValueExpressionResolution.SingleNode,
        ReturnsMode = SlotReturnsMode.Lambda,
        // `csv-tree,node-list` — CSV is STRICTLY a flat list of rows.
        // The `node-list` branch is the right structural parent;
        // `lambda-tree` would imply "arbitrary structure" which CSV
        // does NOT have. Per the mutual-exclusion rule between the
        // node-list and lambda-tree branches: producers commit to ONE
        // (csv2lambda is firmly in the node-list branch). `csv-tree`
        // keys into the `csv-tree:` sample catalog for prelude
        // materialization. Each row IS structured (named columns) and
        // is tagged `csv-row,lambda-tree` at the element level — that
        // structural fact is internal to each row, not the outer list.
        ReturnsKind = "csv-tree,node-list",
        ReturnsElementKind = "csv-row,lambda-tree",
        ReturnsDescription = "Resolves to the parsed lambda hierarchy as child nodes; each child is one CSV row containing column-named values",
        SignatureType = typeof(global::magic.lambda.csv.signatures.Csv2LambdaSignature))]
    public class Csv2Lambda : ISlot
    {
        /// <summary>
        /// Slot implementation.
        /// </summary>
        /// <param name="signaler">Signaler that raised signal.</param>
        /// <param name="input">Arguments to slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Retrieving all arguments, including actual CSV content.
            var args = GetArgs(input);

            // Creating our string reader that CsvParser requires
            using (var reader = new StringReader(args.CSV))
            {
                // Creating our actual CSV parser instance, wrapping StringReader.
                using (var parser = new CsvParser(reader, CultureInfo.InvariantCulture))
                {
                    // Buffer for column names, assuming CSV file contains headers.
                    var columns = GetHeaders(parser);

                    // If above returns null, CSV file is empty.
                    if (!columns.Any())
                        return; // Nothing to see here ...

                    // Reading through each record in CSV file.
                    while (parser.Read())
                    {
                        var cur = new Node(".");
                        for (var idx = 0; idx < columns.Count; idx++)
                        {
                            var stringValue = parser.Record[idx];

                            /*
                             * Converting according to specified type information.
                             */
                            if (stringValue == args.NullableValue)
                                cur.Add(new Node(columns[idx])); // Null value
                            else if (args.Types.TryGetValue(columns[idx], out string type))
                                cur.Add(new Node(columns[idx], Converter.ToObject(stringValue, type))); // We have type information for current cell
                            else
                                cur.Add(new Node(columns[idx], stringValue)); // No type information specified for current cell
                        }
                        input.Add(cur);
                    }
                }
            }
        }

        #region [ -- Private helper methods -- ]

        /*
         * Returns headers from CSV file.
         */
        List<string> GetHeaders(CsvParser parser)
        {
            if (parser.Read())
                return parser.Record.ToList();
            return new List<string>();
        }

        /*
         * Helper method to retrieve arguments to invocation.
         */
        (string CSV, Dictionary<string, string> Types, string NullableValue) GetArgs(Node input)
        {
            // Getting raw CSV text, and making sure we remove any expressions or value in identity node.
            var csv = input.GetEx<string>();
            input.Value = null;

            // Creating our dictionary to hold type information.
            var types = GetTypes(input);

            // Retrieving nullable argument.
            string nullValue = GetNullableValue(input);

            // House cleaning.
            input.Clear();

            return (csv, types, nullValue);
        }

        /*
         * Helper method to retrieve type information from arguments.
         */
        Dictionary<string, string> GetTypes(Node input)
        {
            var types = new Dictionary<string, string>();
            var typesNode = input.Children.FirstOrDefault(x => x.Name == "types");
            if (typesNode != null)
            {
                foreach (var idx in typesNode.Children)
                {
                    types[idx.Name] = idx.GetEx<string>();
                }
            }
            return types;
        }

        /*
         * Helper method to retrieve null string value if existing.
         */
        string GetNullableValue(Node input)
        {
            string nullValue = "[NULL]";
            var nullArgument = input.Children.FirstOrDefault(x => x.Name == "null-value");
            if (nullArgument != null)
                nullValue = nullArgument.GetEx<string>();
            return nullValue;
        }

        #endregion
    }
}
