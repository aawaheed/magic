/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using System.Collections.Concurrent;
using System.Threading;

namespace magic.signals.contracts
{
    public sealed class ExecutionContext
    {
        int _referenceCount = 1;

        public ExecutionContext(string executionId, CancellationTokenSource cancellation)
        {
            ExecutionId = executionId ?? throw new ArgumentNullException(nameof(executionId));
            Cancellation = cancellation ?? throw new ArgumentNullException(nameof(cancellation));
        }

        public string ExecutionId { get; }

        public DateTime StartedUtc { get; } = DateTime.UtcNow;

        public CancellationTokenSource Cancellation { get; }

        public CancellationToken Token => Cancellation.Token;

        public ConcurrentDictionary<string, object> Resources { get; } = new();

        public bool IsCancellationRequested => Token.IsCancellationRequested;

        public int ReferenceCount => Math.Max(Volatile.Read(ref _referenceCount), 0);

        public void Cancel()
        {
            Cancellation.Cancel();
        }

        public void ThrowIfCancellationRequested()
        {
            Token.ThrowIfCancellationRequested();
        }

        public bool AddReference()
        {
            while (true)
            {
                var current = Volatile.Read(ref _referenceCount);
                if (current <= 0)
                    return false;

                if (Interlocked.CompareExchange(ref _referenceCount, current + 1, current) == current)
                    return true;
            }
        }

        public int Release()
        {
            var result = Interlocked.Decrement(ref _referenceCount);
            if (result < 0)
                throw new InvalidOperationException("ExecutionContext reference count dropped below zero");
            return result;
        }
    }
}
