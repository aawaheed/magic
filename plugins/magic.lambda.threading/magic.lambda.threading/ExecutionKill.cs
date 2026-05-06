/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.threading
{
    [Slot(Name = "execution.kill")]
    public class ExecutionKill : ISlot
    {
        readonly IExecutionRegistry _executionRegistry;

        public ExecutionKill(IExecutionRegistry executionRegistry)
        {
            _executionRegistry = executionRegistry;
        }

        public void Signal(ISignaler signaler, Node input)
        {
            var id = input.GetEx<string>();
            input.Value = _executionRegistry.TryCancel(id);
            Console.WriteLine($"Execution {id} was successfully killed");
        }
    }
}
