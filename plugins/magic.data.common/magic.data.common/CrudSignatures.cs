/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.data.common.signatures
{
    /// <summary>
    /// Child signature for [sql.create].
    /// </summary>
    public class SqlCreateSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new[]
        {
            Table(SlotChildCardinality.ExactlyOne, false),
            Values(),
        };

        internal static SlotChild Table(SlotChildCardinality cardinality, bool readFeatures)
        {
            var result = new SlotChild
            {
                Name = "table",
                Type = "string",
                Kind = "table-name",
                Description = "Table name to use in the SQL statement",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = cardinality,
            };
            if (readFeatures)
            {
                result.Children.Add(new SlotChild
                {
                    Name = "as",
                    Type = "string",
                    Kind = "table-alias",
                    Description = "Optional table alias",
                    Required = false,
                    Mode = SlotChildMode.ValueOrExpression,
                    Cardinality = SlotChildCardinality.ZeroOrOne,
                });
                result.Children.Add(Join(1));
            }
            return result;
        }

        internal static SlotChild Values()
        {
            return new SlotChild
            {
                Name = "values",
                Type = "lambda",
                Description = "Column values to insert or update",
                Required = true,
                Mode = SlotChildMode.DynamicNamedValues,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "object",
                        Kind = "sql-column-value,text,number,boolean,date,guid,content,value",
                        Description = "Column name and value",
                        Required = true,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.OneOrMore,
                    },
                },
            };
        }

        internal static SlotChild Where()
        {
            return new SlotChild
            {
                Name = "where",
                Type = "lambda",
                Kind = "sql-predicate-root",
                Description = "Optional boolean predicate tree",
                Required = false,
                Mode = SlotChildMode.StructuredArguments,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Children =
                {
                    BooleanLevel("and", 1),
                    BooleanLevel("or", 1),
                },
            };
        }

        internal static SlotChild BooleanLevel(string name, int depth)
        {
            var result = new SlotChild
            {
                Name = name,
                Type = "lambda",
                Kind = "sql-predicate-group",
                Description = $"Boolean {name.ToUpperInvariant()} group",
                Required = false,
                Mode = SlotChildMode.StructuredArguments,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Children =
                {
                    Condition(),
                },
            };
            if (depth > 0)
            {
                result.Children.Add(BooleanLevel("and", depth - 1));
                result.Children.Add(BooleanLevel("or", depth - 1));
            }
            return result;
        }

        internal static SlotChild Condition()
        {
            return new SlotChild
            {
                Name = "*",
                Type = "object",
                Kind = "sql-column-condition,text,number,boolean,date,guid,content,value",
                Description = "Column condition; suffix the name with .eq, .neq, .gt, .gte, .lt, .lte, .like, .ilike, or .in to select an operator",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.TwoOrMore,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "object",
                        Kind = "text,number,boolean,date,guid,content,value",
                        Description = "Value item used by operators such as .in",
                        Required = false,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                    },
                },
            };
        }

        internal static SlotChild Join(int depth)
        {
            var result = new SlotChild
            {
                Name = "join",
                Type = "string",
                Kind = "table-name",
                Description = "Joined table name",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Children =
                {
                    new SlotChild
                    {
                        Name = "type",
                        Type = "string",
                        Kind = "join-type",
                        Description = "Join type: inner, left, right, or full",
                        Required = false,
                        DefaultValue = "inner",
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.ZeroOrOne,
                    },
                    new SlotChild
                    {
                        Name = "as",
                        Type = "string",
                        Kind = "table-alias",
                        Description = "Optional joined table alias",
                        Required = false,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.ZeroOrOne,
                    },
                    new SlotChild
                    {
                        Name = "on",
                        Type = "lambda",
                        Kind = "sql-predicate-root",
                        Description = "Join predicate tree comparing columns or explicit parameters",
                        Required = true,
                        Mode = SlotChildMode.StructuredArguments,
                        Cardinality = SlotChildCardinality.ExactlyOne,
                        Children =
                        {
                            BooleanLevel("and", 1),
                            BooleanLevel("or", 1),
                        },
                    },
                },
            };
            if (depth > 0)
                result.Children.Add(Join(depth - 1));
            return result;
        }
    }

    /// <summary>
    /// Child signature for [sql.read].
    /// </summary>
    public class SqlReadSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new[]
        {
            SqlCreateSignature.Table(SlotChildCardinality.OneOrMore, true),
            Columns(),
            SqlCreateSignature.Where(),
            Group(),
            Order(),
            Limit(),
            Offset(),
            ExplicitArgument(),
        };

        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> OutputChildren => new[] { RowList() };

        // Row-list output shape: every read/select slot returns one unnamed
        // child per row, each row carrying the selected columns as named
        // children. Column names are derived at synthesis time from the
        // statement (column list, aggregate aliases, etc.), so the per-row
        // child set is declared as a wildcard.
        internal static SlotChild RowList()
        {
            return new SlotChild
            {
                Name = ".",
                Type = "lambda",
                Kind = "row",
                Description = "One row returned by the read; child nodes carry the selected column values, with each child's name being the column name or alias from the SELECT statement",
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.StructuredTree,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Kind = "column-value",
                        Description = "Column value; child name is the column name (or alias) declared in the read",
                        Required = false,
                        Mode = SlotChildMode.Value,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            };
        }

        internal static SlotChild Columns()
        {
            return new SlotChild
            {
                Name = "columns",
                Type = "lambda",
                Description = "Columns or aggregate expressions to select; omitted or empty means all columns",
                Required = false,
                Mode = SlotChildMode.DynamicNamedValues,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Kind = "column-name,aggregate-expression",
                        Description = "Column name or aggregate expression; optional [as] child declares an alias",
                        Required = false,
                        Mode = SlotChildMode.Value,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Children =
                        {
                            new SlotChild
                            {
                                Name = "as",
                                Type = "string",
                                Kind = "column-alias",
                                Description = "Column alias",
                                Required = false,
                                Mode = SlotChildMode.ValueOrExpression,
                                Cardinality = SlotChildCardinality.ZeroOrOne,
                            },
                        },
                    },
                },
            };
        }

        internal static SlotChild Group()
        {
            return new SlotChild
            {
                Name = "group",
                Type = "lambda",
                Description = "Columns or aggregate expressions to group by",
                Required = false,
                Mode = SlotChildMode.DynamicNamedValues,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Kind = "column-name,aggregate-expression",
                        Description = "Column name or aggregate expression",
                        Required = false,
                        Mode = SlotChildMode.Value,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                    },
                },
            };
        }

        internal static SlotChild Order()
        {
            return new SlotChild
            {
                Name = "order",
                Type = "string",
                Kind = "column-name,aggregate-expression",
                Description = "Column, comma-separated columns, or aggregate expression to order by",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Children =
                {
                    Direction("Order direction for this specific order node"),
                },
            };
        }

        internal static SlotChild Direction(string description = "Default order direction")
        {
            return new SlotChild
            {
                Name = "direction",
                Type = "string",
                Kind = "sort-direction",
                Description = description,
                Required = false,
                DefaultValue = "asc",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            };
        }

        internal static SlotChild Limit()
        {
            return new SlotChild
            {
                Name = "limit",
                Type = "long",
                Description = "Maximum number of rows to return; omitted defaults to 25 and -1 suppresses the generated limit clause",
                Required = false,
                DefaultValue = "25",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            };
        }

        internal static SlotChild Offset()
        {
            return new SlotChild
            {
                Name = "offset",
                Type = "long",
                Description = "Number of rows to skip",
                Required = false,
                DefaultValue = "0",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            };
        }

        internal static SlotChild ExplicitArgument()
        {
            return new SlotChild
            {
                Name = "@*",
                Type = "object",
                Kind = "sql-parameter-value,text,number,boolean,date,guid,content,value",
                Description = "Explicit SQL parameter supplied by name for generated statements that reference it",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
            };
        }
    }

    /// <summary>
    /// Child signature for [sql.update].
    /// </summary>
    public class SqlUpdateSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new[]
        {
            SqlCreateSignature.Table(SlotChildCardinality.ExactlyOne, false),
            SqlCreateSignature.Values(),
            SqlCreateSignature.Where(),
        };
    }

    /// <summary>
    /// Child signature for [sql.delete].
    /// </summary>
    public class SqlDeleteSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new[]
        {
            SqlCreateSignature.Table(SlotChildCardinality.ExactlyOne, false),
            SqlCreateSignature.Where(),
        };
    }

    /// <summary>
    /// Child signature for executable create CRUD slots.
    /// </summary>
    public class DbCreateSignature : SqlCreateSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Generate(),
            ReturnId(),
            Table(SlotChildCardinality.ExactlyOne, false),
            Values(),
            SqlReadSignature.ExplicitArgument(),
        };

        internal static SlotChild Generate()
        {
            return new SlotChild
            {
                Name = "generate",
                Type = "bool",
                Description = "Whether to only generate SQL and parameter nodes instead of executing it",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            };
        }

        internal static SlotChild ReturnId()
        {
            return new SlotChild
            {
                Name = "return-id",
                Type = "bool",
                Description = "Whether to return the created row ID",
                Required = false,
                DefaultValue = "true",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            };
        }
    }

    /// <summary>
    /// Child signature for executable read CRUD slots.
    /// </summary>
    public class DbReadSignature : SqlReadSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DbCreateSignature.Generate(),
            SqlCreateSignature.Table(SlotChildCardinality.OneOrMore, true),
            Columns(),
            SqlCreateSignature.Where(),
            Group(),
            Order(),
            Limit(),
            Offset(),
            ExplicitArgument(),
        };
    }

    /// <summary>
    /// Child signature for executable update CRUD slots.
    /// </summary>
    public class DbUpdateSignature : SqlUpdateSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DbCreateSignature.Generate(),
            SqlCreateSignature.Table(SlotChildCardinality.ExactlyOne, false),
            SqlCreateSignature.Values(),
            SqlCreateSignature.Where(),
            SqlReadSignature.ExplicitArgument(),
        };
    }

    /// <summary>
    /// Child signature for executable delete CRUD slots.
    /// </summary>
    public class DbDeleteSignature : SqlDeleteSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DbCreateSignature.Generate(),
            SqlCreateSignature.Table(SlotChildCardinality.ExactlyOne, false),
            SqlCreateSignature.Where(),
            SqlReadSignature.ExplicitArgument(),
        };
    }

    /// <summary>
    /// Child signature for dispatching data create slots.
    /// </summary>
    public class DataCreateSignature : DbCreateSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DatabaseType(),
            Generate(),
            ReturnId(),
            Table(SlotChildCardinality.ExactlyOne, false),
            Values(),
            SqlReadSignature.ExplicitArgument(),
        };

        internal static SlotChild DatabaseType()
        {
            return new SlotChild
            {
                Name = "database-type",
                Type = "string",
                Kind = "database-type",
                Description = "Database adapter to use instead of the configured default",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
            };
        }
    }

    /// <summary>
    /// Child signature for dispatching data read and scan slots.
    /// </summary>
    public class DataReadSignature : DbReadSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DataCreateSignature.DatabaseType(),
            DbCreateSignature.Generate(),
            SqlCreateSignature.Table(SlotChildCardinality.OneOrMore, true),
            Columns(),
            SqlCreateSignature.Where(),
            Group(),
            Order(),
            Limit(),
            Offset(),
            ExplicitArgument(),
        };
    }

    /// <summary>
    /// Child signature for dispatching data update slots.
    /// </summary>
    public class DataUpdateSignature : DbUpdateSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DataCreateSignature.DatabaseType(),
            DbCreateSignature.Generate(),
            SqlCreateSignature.Table(SlotChildCardinality.ExactlyOne, false),
            SqlCreateSignature.Values(),
            SqlCreateSignature.Where(),
            SqlReadSignature.ExplicitArgument(),
        };
    }

    /// <summary>
    /// Child signature for dispatching data delete slots.
    /// </summary>
    public class DataDeleteSignature : DbDeleteSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DataCreateSignature.DatabaseType(),
            DbCreateSignature.Generate(),
            SqlCreateSignature.Table(SlotChildCardinality.ExactlyOne, false),
            SqlCreateSignature.Where(),
            SqlReadSignature.ExplicitArgument(),
        };
    }

    /// <summary>
    /// Child signature for raw SQL execution slots.
    /// </summary>
    public class DataExecuteSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new[]
        {
            DataCreateSignature.DatabaseType(),
            SqlParameter(),
        };

        /// <inheritdoc />
        // Declared virtual so [data.select] / dialect select slots can override
        // with the row-list shape without falling into DIM-shadow (the class
        // member would otherwise be hidden from `ISlotSignature` dispatch).
        public virtual IEnumerable<SlotChild> OutputChildren => new SlotChild[0];

        internal static SlotChild SqlParameter()
        {
            return new SlotChild
            {
                Name = "*",
                Type = "object",
                Kind = "sql-parameter-value,text,number,boolean,date,guid,content,value",
                Description = "SQL parameter value; child name is used as the parameter name referenced by the SQL statement",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    /// <summary>
    /// Child signature for concrete raw SQL execution slots.
    /// </summary>
    public class DbExecuteSignature : DataExecuteSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            SqlParameter(),
        };
    }

    /// <summary>
    /// Child signature for raw SQL select slots.
    /// </summary>
    public class DataSelectSignature : DataExecuteSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            DataCreateSignature.DatabaseType(),
            Max(),
            MultipleResultSets(),
            SqlParameter(),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotChild> OutputChildren => new[] { SqlReadSignature.RowList() };

        internal static SlotChild Max()
        {
            return new SlotChild
            {
                Name = "max",
                Type = "long",
                Description = "Maximum number of rows to return; omitted or -1 returns all rows",
                Required = false,
                DefaultValue = "-1",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }

        internal static SlotChild MultipleResultSets()
        {
            return new SlotChild
            {
                Name = "multiple-result-sets",
                Type = "bool",
                Description = "Whether multiple SELECT statements in the SQL input should be returned as separate child result containers",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    /// <summary>
    /// Child signature for concrete raw SQL select slots.
    /// </summary>
    public class DbSelectSignature : DataSelectSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Max(),
            MultipleResultSets(),
            SqlParameter(),
        };
    }
}
