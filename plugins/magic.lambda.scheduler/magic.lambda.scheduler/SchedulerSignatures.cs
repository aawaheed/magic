/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.scheduler.signatures
{
    /// <summary>
    /// Signature helpers for scheduler slots.
    /// </summary>
    public abstract class SchedulerSignature : ISlotSignature
    {
        /// <inheritdoc />
        public abstract IEnumerable<SlotChild> Children { get; }

        internal static SlotChild Option(string name, string type, string description, bool required = false, string kind = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Kind = kind,
                Description = description,
                Required = required,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }

        internal static SlotChild Lambda()
        {
            return new SlotChild
            {
                Name = ".lambda",
                Type = "lambda",
                Description = "Task body serialized and executed later",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.LambdaBlock,
                Evaluation = SlotChildEvaluation.SerializeLambda,
                Projection = SlotChildProjection.Children,
            };
        }

        internal static SlotConstraint AtLeastOneSchedule()
        {
            var result = new SlotConstraint
            {
                Kind = SlotConstraintKind.AtLeastOneOf,
                Description = "At least one schedule source must be supplied",
            };
            result.Values.AddRange(new[] { "due", "repeats" });
            return result;
        }
    }

    /// <summary>
    /// Signature for [tasks.create].
    /// </summary>
    public class CreateTaskSignature : SchedulerSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("description", "string", "Optional task description", kind: "task-description"),
            Option("due", "DateTime", "Optional one-time due date", kind: "date"),
            Option("repeats", "string", "Optional repeat pattern", kind: "task-repeat-pattern"),
            Lambda(),
        };
    }

    /// <summary>
    /// Signature for [tasks.schedule].
    /// </summary>
    public class ScheduleTaskSignature : SchedulerSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("due", "DateTime", "One-time due date", kind: "date"),
            Option("repeats", "string", "Repeat pattern", kind: "task-repeat-pattern"),
        };

        /// <inheritdoc />
        public IEnumerable<SlotConstraint> Constraints => new[]
        {
            AtLeastOneSchedule(),
        };
    }

    /// <summary>
    /// Signature for [tasks.get].
    /// </summary>
    public class GetTaskSignature : SchedulerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("schedules", "bool", "Whether to include schedules for the task"),
        };
    }

    /// <summary>
    /// Signature for [tasks.list].
    /// </summary>
    public class ListTasksSignature : SchedulerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("offset", "long", "Number of tasks to skip"),
            Option("limit", "long", "Maximum number of tasks to return"),
        };
    }
}
