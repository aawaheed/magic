/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.wait-for-timeout] slot for sleeping N milliseconds.
    /// </summary>
    [Slot(Name = "puppeteer.wait-for-timeout")]
    public class WaitForTimeout : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var timeout = input.GetEx<int>();
            if (timeout < 0)
                throw new HyperlambdaException("[puppeteer.wait-for-timeout] requires a non-negative integer");

            await Task.Delay(timeout);

            input.Clear();
            input.Value = null;
        }
    }
}
