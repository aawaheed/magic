/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using magic.signals.contracts;
using magic.data.common.helpers;
using magic.data.common.contracts;

namespace magic.data.common.slots
{
    /// <summary>
    /// [data.scalar] slot, for executing some SQL towards a database and returning a scalar result,
    /// according to your configuration settings.
    /// </summary>
    [Slot(
        Name = "data.scalar",
        Description = "Executes SQL and returns a scalar value from the current database connection",
        ValueType = "string",
        ValueDescription = "SQL statement to execute",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "object",
        ReturnsDescription = "Resolves to a scalar value from the current database connection",
        RequiresScope = "data.connection",
        ScopeProvider = "data.connect",
        ScopeDescription = "Requires an open database connection created by [data.connect]",
        SignatureType = typeof(global::magic.data.common.signatures.DataExecuteSignature))]
    public class Scalar : DataSlotBase
    {
        /// <summary>
        /// Creates a new instance of your type.
        /// </summary>
        /// <param name="settings">Configuration object.</param>
        public Scalar(IDataSettings settings)
            : base(".scalar", settings)
        { }
    }
}
