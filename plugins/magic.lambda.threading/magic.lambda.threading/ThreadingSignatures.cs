/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.threading.signatures
{
    public class ForkSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Executable child slot evaluated on the forked thread",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
            },
        };
    }

    public class SemaphoreSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Executable child lambda object evaluated while the named semaphore is held",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
            },
        };
    }

    public class JoinSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "fork",
                Type = "lambda",
                Description = "Fork body to start and wait for; evaluated body node values and children are preserved in the completed fork node",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.ExecutableBody,
                // `SerializeLambda` declares "body executes in isolated
                // runtime context" — the synth's generic name for the
                // clone/serialize-then-parse/detach property. Join.cs
                // clones each [fork] child (`idxThread.Clone()`) and
                // evaluates the clone on a separate thread; the clone
                // is detached from [join]'s DOM, so expressions inside
                // can't resolve outer-scope references. Same flag the
                // synth uses for [tasks.create]/[.lambda] (serialized
                // to DB) — different mechanism, same isolation property.
                Evaluation = SlotChildEvaluation.SerializeLambda,
                Projection = SlotChildProjection.Self,
            },
        };
    }
}
