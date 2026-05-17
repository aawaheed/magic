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
        /// Optional semantic kind for the child node's value or projected payload.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Optional CLR-ish element type for expression/list/tree payloads.
        /// </summary>
        public string ElementType { get; set; }

        /// <summary>
        /// Optional semantic element kind for expression/list/tree payloads.
        /// </summary>
        public string ElementKind { get; set; }

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
        /// Optional cross-argument link. When set, this child's contents are
        /// derived from the parent slot's `.Value` (or a sibling) parsed for
        /// template tokens, when the parent's ValueKind matches this tag.
        /// Used to wire dynamic-named arg containers like `[url-params]` to
        /// the `{token}` placeholders inside a `url-template` parent value.
        /// Tooling (corpus synthesizer, doc generator) reads this to keep
        /// linked args consistent with the value they reference.
        /// </summary>
        public string LinkedToValueKind { get; set; }

        /// <summary>
        /// Regex pattern used to extract template tokens from the linked
        /// value, with capture group 1 holding the token name. Defaults to
        /// `\{([^}]+)\}` (the `{token}` URL-template syntax) when
        /// LinkedToValueKind is set without an explicit pattern.
        /// </summary>
        public string LinkedTokenPattern { get; set; }

        /// <summary>
        /// Structural constraints applying to this child node.
        /// </summary>
        public List<SlotConstraint> Constraints { get; } = new List<SlotConstraint>();

        /// <summary>
        /// Nested child nodes accepted by this child node.
        /// </summary>
        public List<SlotChild> Children { get; } = new List<SlotChild>();

        /// <summary>
        /// For ExecutableLambda bodies: children of the synthetic
        /// [.arguments] bag the parent slot injects at invocation. Mirrors
        /// the iteration-pointer pattern used by [for-each]/[map]/etc.
        /// (which surfaces @.dp/# inside their body), but with a fixed
        /// .arguments root name instead of .dp. Empty (default) means the
        /// body inherits no caller-injected arguments.
        ///
        /// Each entry's Name/Type/Kind/Description documents one child of
        /// the [.arguments] bag. Inside the body, path enumeration surfaces
        /// @.arguments/&lt;name&gt; with the declared kind/type so the
        /// body slot picker and PickValue wire consumers automatically.
        /// Example: HTTP [.sse] callbacks receive [.arguments/message]
        /// (one SSE line per body invocation), declared on the [.sse]
        /// schema as Arguments = { Name="message", Kind="text-line,text" }.
        /// </summary>
        public List<SlotChild> Arguments { get; } = new List<SlotChild>();
    }
}
