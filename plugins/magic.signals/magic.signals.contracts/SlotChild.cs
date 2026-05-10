/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;

namespace magic.signals.contracts
{
    /// <summary>
    /// Documents a single child node accepted by a slot.
    /// </summary>
    public class SlotChild
    {
        /// <summary>
        /// Child node name. Use "*" for dynamic child names.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CLR-ish type name for the child node's value.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Description of the child node.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the child node is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Optional default value description.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// How the child node's value or body should be interpreted.
        /// </summary>
        public SlotChildMode Mode { get; set; }

        /// <summary>
        /// Cardinality for the child node.
        /// </summary>
        public SlotChildCardinality Cardinality { get; set; }

        /// <summary>
        /// Optional name of a mutually exclusive signature section.
        /// </summary>
        public string ExclusiveWith { get; set; }

        /// <summary>
        /// Optional preprocessing applied before the child nodes are consumed.
        /// </summary>
        public SlotChildPreprocess Preprocess { get; set; }

        /// <summary>
        /// Semantic role this child node plays in the slot invocation.
        /// </summary>
        public SlotChildRole Role { get; set; }

        /// <summary>
        /// Optional evaluation behavior applied before the child is consumed.
        /// </summary>
        public SlotChildEvaluation Evaluation { get; set; }

        /// <summary>
        /// Which part of this child is consumed after optional evaluation.
        /// </summary>
        public SlotChildProjection Projection { get; set; }

        /// <summary>
        /// Structural constraints applying to this child node.
        /// </summary>
        public List<SlotConstraint> Constraints { get; } = new List<SlotConstraint>();

        /// <summary>
        /// Nested child nodes accepted by this child node.
        /// </summary>
        public List<SlotChild> Children { get; } = new List<SlotChild>();
    }
}
