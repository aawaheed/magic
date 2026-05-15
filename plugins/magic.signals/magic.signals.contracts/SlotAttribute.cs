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
    }
}
