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
        /// Optional description of the slot's documented return payload.
        /// </summary>
        public string ReturnsDescription { get; set; }

        /// <summary>
        /// Optional type providing structured documentation for child nodes
        /// accepted by the slot.
        /// </summary>
        public Type SignatureType { get; set; }
    }
}
