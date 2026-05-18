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
        ReturnsType = "lambda",
        // `string-list` added — each child node's value is a cookie-value
        // string (the child name is the cookie name). Consumers asking for
        // "list of strings" must kind-match; semantic identity preserved by
        // `cookie-list`.
        ReturnsKind = "cookie-list,string-list,node-list",
        ReturnsElementType = "string",
        ReturnsElementKind = "cookie-value",
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
