/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using magic.node;
using magic.signals.contracts;
using magic.node.extensions;
using System.Linq;

namespace magic.lambda.threading
{
    /// <summary>
    /// [fork] slot, allowing you to create and start a new thread.
    /// </summary>
    [Slot(
        Name = "fork",
        Description = "Creates a new thread and executes the specified lambda object on the new thread")]
    public class Fork : ISlotAsync
    {
        readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// Creates an instance of your type
        /// </summary>
        /// <param name="serviceScopeFactory">Used to create new scope to prevent race conditions</param>
        public Fork(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #pragma warning disable 1998
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        /// <returns>An awaiatble task.</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            // Retrieving username, roles, and claims, if these exists.
            var auth = new Node();
            signaler.Signal("auth.ticket.get", auth);
            var execution = signaler.GetExecutionContext();
            if (execution != null && !execution.AddReference())
                execution = null;

            // Notice, NOT awaiting task, which is intentional to ensure we're creating a "fire and forget" thread.
            _ = Task.Run(async () => 
            {
                // Notice, ISignaler is NOT thread safe, since it preserves state on a per thread individual basis.
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        if (auth.Value != null)
                        {
                            // Passing in auth ticket to thread as a scoped context object.
                            var threadSignaler = scope.ServiceProvider.GetService<ISignaler>();
                            await threadSignaler.ScopeAsync(".auth.ticket.get", auth.Clone(), async () =>
                            {
                                if (execution != null)
                                {
                                    await threadSignaler.ScopeAsync("execution.context", execution, async () =>
                                    {
                                        await threadSignaler.ScopeAsync("dynamic.execution-id", execution.ExecutionId, async () =>
                                        {
                                            await threadSignaler.SignalAsync("eval", input.Clone());
                                        });
                                    });
                                }
                                else
                                {
                                    await threadSignaler.SignalAsync("eval", input.Clone());
                                }
                            });
                        }
                        else
                        {
                            // No auth object.
                            var threadSignaler = scope.ServiceProvider.GetService<ISignaler>();
                            if (execution != null)
                            {
                                await threadSignaler.ScopeAsync("execution.context", execution, async () =>
                                {
                                    await threadSignaler.ScopeAsync("dynamic.execution-id", execution.ExecutionId, async () =>
                                    {
                                        await threadSignaler.SignalAsync("eval", input.Clone());
                                    });
                                });
                            }
                            else
                            {
                                await threadSignaler.SignalAsync("eval", input.Clone());
                            }
                        }
                    }
                }
                finally
                {
                    if (execution != null)
                        execution.Release();
                }
            });
        }
        #pragma warning restore 1998
    }
}
