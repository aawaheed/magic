/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Threading;

namespace magic.signals.contracts
{
    public interface IExecutionRegistry
    {
        ExecutionContext Create(CancellationToken cancellationToken = default);

        bool TryCancel(string executionId);

        bool TryGet(string executionId, out ExecutionContext context);

        void Complete(string executionId);
    }
}
