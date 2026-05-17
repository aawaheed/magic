/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;

namespace magic.signals.contracts
{
    /// <summary>
    /// Attribute class you need to mark your signals with, to associate your
    /// slot with a string/name.
    ///
    /// Its name can later be used to invoke your slot using the ISignaler.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SlotAttribute : Attribute
    {
        /// <summary>
        /// Runtime name of the iteration-pointer node injected into the body
        /// scope of slots whose <see cref="ProvidesIterationPointer"/> is true
        /// (for-each / map / filter / include). Formalizes the convention
        /// already documented in prose on that property and hardcoded in the
        /// iterator slot implementations — exposed as a const so the
        /// synthesizer and other meta-tooling can generate scope-aware
        /// expressions without re-declaring the literal.
        /// </summary>
        public const string IterationPointerName = ".dp";

        /// <summary>
        /// Name of slot.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of slot.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional CLR-ish type name for the slot's input value argument.
        /// </summary>
        public string ValueType { get; set; }

        /// <summary>
        /// Optional semantic kind for the slot's input value argument.
        /// </summary>
        public string ValueKind { get; set; }

        /// <summary>
        /// Optional description of the slot's input value argument.
        /// </summary>
        public string ValueDescription { get; set; }

        /// <summary>
        /// Indicates whether the slot's input value argument is required.
        /// </summary>
        public bool ValueRequired { get; set; }

        /// <summary>
        /// Indicates how the slot's input value argument should be interpreted.
        /// Defaults to <see cref="SlotValueMode.None"/> for slots without a
        /// documented input value argument.
        /// </summary>
        public SlotValueMode ValueMode { get; set; }

        /// <summary>
        /// Indicates the slot's primary documented return shape.
        /// Defaults to <see cref="SlotReturnsMode.None"/> for slots without a
        /// documented return contract.
        /// </summary>
        public SlotReturnsMode ReturnsMode { get; set; }

        /// <summary>
        /// Optional CLR-ish type name for the slot's documented return payload.
        /// For <see cref="SlotReturnsMode.Value"/> this describes
        /// <see cref="magic.node.Node.Value"/>, and for
        /// <see cref="SlotReturnsMode.Lambda"/> it describes the child-node
        /// payload returned from the slot.
        /// </summary>
        public string ReturnsType { get; set; }

        /// <summary>
        /// Optional semantic kind for the slot's documented return payload.
        /// </summary>
        public string ReturnsKind { get; set; }

        /// <summary>
        /// Optional CLR-ish type name for elements returned as child nodes.
        /// </summary>
        public string ReturnsElementType { get; set; }

        /// <summary>
        /// Optional semantic kind for elements returned as child nodes.
        /// </summary>
        public string ReturnsElementKind { get; set; }

        /// <summary>
        /// Optional description of the slot's documented return payload.
        /// </summary>
        public string ReturnsDescription { get; set; }

        /// <summary>
        /// Optional type providing structured documentation for child nodes
        /// accepted by the slot.
        /// </summary>
        public Type SignatureType { get; set; }

        /// <summary>
        /// Optional runtime scope provided by this slot while evaluating its
        /// executable child lambda.
        /// </summary>
        public string ProvidesScope { get; set; }

        /// <summary>
        /// Optional runtime scope required for this slot to be meaningful.
        /// </summary>
        public string RequiresScope { get; set; }

        /// <summary>
        /// Optional slot that creates the required runtime scope.
        /// </summary>
        public string ScopeProvider { get; set; }

        /// <summary>
        /// Optional source for the scope key, for instance "input" when the
        /// provider and consumer must use the same input value.
        /// </summary>
        public string ScopeKey { get; set; }

        /// <summary>
        /// Optional human-readable description of the runtime scope contract.
        /// </summary>
        public string ScopeDescription { get; set; }

        /// <summary>
        /// True if this slot clones its [.lambda] body before evaluating it.
        /// Cloned lambdas are detached from their original parent tree, so
        /// expressions inside the body cannot resolve nodes that live outside
        /// the [.lambda] block (siblings of this slot, ancestor preludes, etc.).
        /// The synthesizer uses this to keep generated body content self-contained.
        /// </summary>
        public bool ClonesLambda { get; set; }

        /// <summary>
        /// Optional comma-separated list of state kinds that must have been
        /// established by an earlier sibling slot before this slot is meaningful.
        /// Each kind is matched against the <see cref="ReturnsKind"/> of other
        /// slots; the synthesizer chains the establishing slots into the prelude.
        ///
        /// Use this for sequential state contracts where the relationship is NOT
        /// structural (i.e. parent/child nesting via <see cref="RequiresScope"/>)
        /// but ordering — e.g. a Puppeteer page-read slot requires that a
        /// previous sibling has navigated the page via [puppeteer.goto].
        /// </summary>
        public string Preconditions { get; set; }

        /// <summary>
        /// Declares the structural shape of the slot's lambda body when one is
        /// present. Used by the synthesizer to route body generation through a
        /// dedicated builder per shape, replacing per-slot rule lists.
        /// </summary>
        public SlotBodyShape BodyShape { get; set; }

        /// <summary>
        /// True if this slot terminates the surrounding lambda block at runtime
        /// (return, return-nodes, return-value, throw, tasks.schedule). The
        /// synthesizer treats terminators differently across several layers:
        /// they're inserted last in a block, they're excluded from pipeline
        /// output usage, and their wildcard children aren't pipeline targets.
        /// </summary>
        public bool IsBlockTerminator { get; set; }

        /// <summary>
        /// True if the slot's output can drive downstream pipeline steps.
        /// Default true. Terminal slots and side-effect-only slots set this
        /// to false so the pipeline planner doesn't try to consume their
        /// output as a source.
        /// </summary>
        public bool PipelineOutputUsable { get; set; } = true;

        /// <summary>
        /// True if the slot can accept a pipeline-injected input value or
        /// child wiring. Default true. Slots whose input must be the literal
        /// declared at synthesis time (e.g. validators.regex, where the
        /// pattern must match the validated value declared in a prelude) set
        /// this to false.
        /// </summary>
        public bool AcceptsPipelineInput { get; set; } = true;

        /// <summary>
        /// True if the slot exposes the iteration data pointer @.dp/# to its
        /// executable body. Set on for-each, map, filter, include. The body
        /// builder uses this flag to decide whether body templates referencing
        /// @.dp/# are safe in this context.
        /// </summary>
        public bool ProvidesIterationPointer { get; set; }

        /// <summary>
        /// True if the slot writes to the ambient `slots.result` scope when
        /// invoked (return / return-value / return-nodes / yield). Slots
        /// whose executable-lambda children have
        /// <see cref="SlotChildProjection.ReturnedResult"/> (map, include,
        /// filter, invoke targets, …) require their body to call one of
        /// these so the caller observes a value/child set. The synthesizer
        /// uses this flag to restrict dynamic body element candidates inside
        /// such bodies — picking a side-effect-only slot would leave
        /// `slots.result` empty and cause the parent to throw at runtime.
        /// </summary>
        public bool WritesScopeResult { get; set; }

        /// <summary>
        /// True if the slot's payload is delivered EITHER via its value
        /// (typically an expression evaluating to nodes/values) OR via its
        /// child nodes — but never neither. Runtime semantics: if Value is
        /// set, it takes precedence; otherwise the slot reads Children.
        /// Examples: [return-nodes] / [yield] accept either an expression
        /// pointing at a node-list or literal child nodes; emitting them
        /// bare with neither produces no output and teaches the LLM a
        /// nonsense form.
        ///
        /// When this flag is true, the synthesizer treats the two paths as
        /// alternatives: it picks ONE form per emission (coin-flip) so the
        /// corpus contains clean examples of each idiom rather than the
        /// redundant both-at-once form. The flag is opt-in — no slot is
        /// affected by default.
        /// </summary>
        public bool ValueOrChildrenRequired { get; set; }

        /// <summary>
        /// True if the slot's output preserves the row shape of its input
        /// expression — i.e. it selects, reorders, mutates, or augments
        /// nodes pointed to by its expression value rather than producing
        /// a transformed result. Set on slots like [get-nodes] (selects
        /// matching nodes), [sort] (reorders same set), [set-name] /
        /// [set-value] / [set-x] (mutates in place). The synthesizer reads
        /// this flag in MaybeRegisterRowShape: when the source expression
        /// has a known row shape, the slot's own output gets registered
        /// with the same shape so downstream consumers see
        /// `@&lt;slot&gt;/*/&lt;field&gt;` paths as valid.
        /// </summary>
        public bool PreservesInputShape { get; set; }

        /// <summary>
        /// True if the slot's scope cannot tolerate a mid-pipeline exit —
        /// i.e. all of its children must execute and the scope cannot be
        /// closed early so steps following it land at the outer level. Set
        /// on *.transaction.create (would orphan the transaction) and on
        /// filter/map/include (lambda body is consumed as a single
        /// expression).
        /// </summary>
        public bool ScopeRequiresStrictExit { get; set; }

        /// <summary>
        /// True if the slot's return value depends on external state (RNG,
        /// cache contents, token counter, …) and therefore CAN'T be used as
        /// a comparison operand against a static literal — the comparison
        /// could never be predicted at generation time. Set on
        /// openai.tokenize, cache.count, crypto.random and similar.
        /// </summary>
        public bool ReturnIsExternallyStateful { get; set; }

        /// <summary>
        /// Declares how the slot resolves its input expression to a runtime
        /// value. Slots that require the expression to resolve to a SINGLE
        /// node (get-value, get-name, invoke, convert, type, reference) set
        /// SingleNode so the pipeline planner doesn't wire multi-node
        /// (ChildNodes) sources into them.
        /// </summary>
        public SlotValueExpressionResolution ValueExpressionResolution { get; set; }

        /// <summary>
        /// Optional comparison-family tag for slots usable as Magic's
        /// boolean comparisons. Drives the literal-picker that pairs the
        /// right-hand operand value with the comparison's semantics (eq
        /// picks the same value, neq picks a different value, mt picks a
        /// smaller value, lt picks a larger value).
        /// </summary>
        public SlotComparisonKind ComparisonKind { get; set; }

        /// <summary>
        /// Optional name of a child node whose contents the synthesizer must
        /// keep in sync with the slot names invoked by the slot's executable
        /// body. Set on whitelist as "vocabulary": after the body is built,
        /// the post-pass walks the body subtree and ensures every invoked
        /// slot name appears in the named child.
        /// </summary>
        public string RequiresInvokedSlotInventoryChild { get; set; }
    }

    /// <summary>
    /// Body-shape contract for slots whose executable body is generated
    /// outside the standard signature schema walk. Each value identifies a
    /// dedicated body builder that knows the slot's body contract.
    /// </summary>
    public enum SlotBodyShape
    {
        /// <summary>Default — body follows the slot signature's Children.</summary>
        None,
        /// <summary>
        /// Body is a boolean predicate (and/or/single comparison) followed
        /// by a return:x:- result. Used by [filter] and [include].
        /// </summary>
        BooleanPredicate,
        /// <summary>
        /// Body is a list of [case] entries plus an optional [default]
        /// where case values match the slot's input. Used by [switch].
        /// </summary>
        SwitchCase,
        /// <summary>
        /// Body consumes a prelude-declared `.convertValue` and converts it
        /// to a target type declared via a child. Used by [convert].
        /// </summary>
        ConvertWithPrelude,
        /// <summary>
        /// Slot wraps a lambda block, taking a context name as its value and
        /// a sibling [value] child. Used by [context].
        /// </summary>
        NamedContext,
        /// <summary>
        /// Slot wraps a lambda block without a value of its own. Used by
        /// [strings.builder].
        /// </summary>
        SimpleScope,
        /// <summary>
        /// Body's children come from a Mustache-style template the slot
        /// reads from a prelude variable. Used by [strings.mixin].
        /// </summary>
        MixinTemplate,
        /// <summary>
        /// Slot invokes a dynamically named slot whose argument set is
        /// determined by inspecting the prelude lambda's [.arguments]
        /// references. Used by [invoke] / [eval] / [eval-async].
        /// </summary>
        InvokeCall,
        /// <summary>
        /// Body must emit row-wrapped yields — `yield > . > N fields` — so
        /// each iteration produces a single addressable row node in the
        /// slot's output. Used by [map]. The synthesizer generates the
        /// wrapped-yield body AND registers the slot's post-run row shape
        /// (`@&lt;slot&gt;/*/<field>`) so downstream consumers can address
        /// those fields.
        /// </summary>
        WrappedRowEmission,
        /// <summary>
        /// Body emits flat yields — `yield > N fields` directly, no `.`
        /// wrapper — because the host slot braids the yielded children
        /// straight into each iterated destination node (decorator). Used
        /// by [include]. Field NAMES come from the iteration source's
        /// known row shape so the decoration corresponds to real columns.
        /// No new addressable output (`@&lt;slot&gt;` is empty after run);
        /// the synthesizer does not register a post-run shape.
        /// </summary>
        BraidedRowEmission,
    }

    /// <summary>
    /// Discriminates how a slot's input expression should resolve at runtime.
    /// </summary>
    public enum SlotValueExpressionResolution
    {
        /// <summary>Default — expression may resolve to one or many nodes.</summary>
        Default,
        /// <summary>
        /// Expression MUST resolve to exactly one node — multi-result
        /// sources are incompatible. Used by get-value / get-name /
        /// invoke / convert / type / reference.
        /// </summary>
        SingleNode,
    }

    /// <summary>
    /// Comparison family for slots that act as Magic's boolean comparisons.
    /// Drives right-hand-operand literal selection.
    /// </summary>
    public enum SlotComparisonKind
    {
        /// <summary>Default — not a comparison slot.</summary>
        None,
        /// <summary>Equality: right operand should be the same value as left.</summary>
        Equality,
        /// <summary>Inequality: right operand should differ from left.</summary>
        Inequality,
        /// <summary>Greater-than (mt / mte): right operand should be smaller than left.</summary>
        GreaterThan,
        /// <summary>Less-than (lt / lte): right operand should be larger than left.</summary>
        LessThan,
    }
}
