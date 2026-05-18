/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using magic.node;
using magic.signals.contracts;
using magic.endpoint.contracts.poco;

namespace magic.endpoint.services.slots.cookies
{
    /// <summary>
    /// [request.cookies.list] slot for listing all cookies attached to the request.
    /// </summary>
    [Slot(
        Name = "request.cookies.list",
        Description = "Lists request cookies",
        ReturnsMode = SlotReturnsMode.Lambda,
        // `cookie-map,lambda-tree` — runtime is
        //   `input.AddRange(request.Cookies.Select(x => new Node(x.Key, x.Value)))`
        // — each child node's NAME is the cookie key, its VALUE is the
        // cookie value. That's the OBJECT pattern (named children), NOT
        // a node-list / string-list (which require anonymous `.` items).
        // Per the mutual-exclusion rule: producers with named children
        // commit to lambda-tree, not the list branches.
        // Renamed `-list` suffix to `-map` to reflect actual shape.
        ReturnsKind = "cookie-map,lambda-tree",
        ReturnsElementKind = "cookie-value,text",
        ReturnsDescription = "Resolves to one child node per request cookie, with the cookie name as the node name and its value as the node value")]
    public class ListCookies : ISlot
    {
        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var request = signaler.Peek<MagicRequest>("http.request");
            input.AddRange(request.Cookies.Select(x => new Node(x.Key, x.Value)));
        }
    }
}
