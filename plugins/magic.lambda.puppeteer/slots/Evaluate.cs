/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using magic.node;
using magic.signals.contracts;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.evaluate] slot for executing a JS expression in the page.
    /// </summary>
    [Slot(Name = "puppeteer.evaluate")]
    public class Evaluate : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(input);
            var expression = PuppeteerHelpers.GetRequiredString(input, "expression");
            var argsNode = input.Children.FirstOrDefault(x => x.Name == "args");
            var args = PuppeteerHelpers.GetArgs(argsNode).Cast<object>().ToArray();

            object result;
            if (args.Length == 0)
                result = await page.EvaluateExpressionAsync<object>(expression);
            else
                result = await page.EvaluateFunctionAsync<object>(expression, args);

            input.Clear();
            if (result is string stringResult)
                input.Value = stringResult;
            else if (result == null)
                input.Value = null;
            else
                input.Value = JsonSerializer.Serialize(result);
        }
    }
}
