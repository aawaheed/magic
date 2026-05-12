/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.sockets.signatures
{
    public abstract class SocketSignature : ISlotSignature
    {
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        protected static SlotChild Option(string name, string type, string description, bool required = false, string defaultValue = null, string kind = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Kind = kind,
                Description = description,
                Required = required,
                DefaultValue = defaultValue,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    public class SocketGroupSignature : SocketSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("group", "string", "Socket group name", true, kind: "socket-group"),
        };
    }

    public class SocketUsersSignature : SocketSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("filter", "string", "Username filter", kind: "username"),
            Option("offset", "int", "Number of matching users to skip", defaultValue: "0"),
            Option("limit", "int", "Maximum number of users to return", defaultValue: "10"),
        };
    }

    public class SocketCountUsersSignature : SocketSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("filter", "string", "Username filter", kind: "username"),
        };
    }

    public class SocketSignalSignature : SocketSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "args",
                Type = "lambda",
                Description = "Payload serialized to JSON and sent with the socket message",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Payload,
                Evaluation = SlotChildEvaluation.UnwrapDescendants,
                Projection = SlotChildProjection.StructuredTree,
            },
            Option("roles", "string", "Comma-separated roles receiving the message", kind: "role"),
            Option("users", "string", "Comma-separated users receiving the message", kind: "username"),
            Option("groups", "string", "Comma-separated groups receiving the message", kind: "socket-group"),
            Option("clients", "string", "Comma-separated connection IDs receiving the message", kind: "socket-connection-id"),
        };
    }
}
