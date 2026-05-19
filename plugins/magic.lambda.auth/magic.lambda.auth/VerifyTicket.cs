/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.lambda.auth.helpers;
using magic.lambda.auth.contracts;

namespace magic.lambda.auth
{
    /// <summary>
    /// [auth.ticket.verify] slot, for verifying that a user is authenticated, and optionally belongs to
    /// one of the roles supplied as a comma separated list of values.
    /// </summary>
    [Slot(
        Name = "auth.ticket.verify",
        Description = "Verifies that the current user is authenticated and optionally in one of the specified roles",
        // `role-list,text` — runtime treats the input as a comma-separated
        // string of roles (e.g. "admin,manager") and passes it to
        // `TicketFactory.VerifyTicket` which splits and checks each.
        // Previous tag was `role` (singular) — flat mischaracterization.
        // `role-list` keys into a dedicated catalog of comma-separated
        // role strings; `text` is the structural parent.
        // 'text' pruned: this slot needs a comma-separated role list, not arbitrary text.
        ValueKind = "role-list",
        ValueDescription = "Optional comma-separated roles to require",
        ValueRequired = false,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.None)]
    public class VerifyTicket : ISlot
    {
        readonly ITicketProvider _ticketProvider;

        /// <summary>
        /// Creates a new instance of class.
        /// </summary>
        /// <param name="ticketProvider">Ticket provider, necessary to retrieve the authenticated user.</param>
        public VerifyTicket(ITicketProvider ticketProvider)
        {
            _ticketProvider = ticketProvider;
        }

        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to signal.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            TicketFactory.VerifyTicket(_ticketProvider, input.GetEx<string>(), signaler);
        }
    }
}
