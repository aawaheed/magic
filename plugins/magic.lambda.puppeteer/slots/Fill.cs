/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Text.Json;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;
using PuppeteerSharp.Input;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.fill] slot for clearing and typing into a selector.
    /// </summary>
    [Slot(Name = "puppeteer.fill")]
    public class Fill : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(input);
            var selector = PuppeteerHelpers.GetRequiredString(input, "selector");
            var text = PuppeteerHelpers.GetOptionalString(input, "text");
            if (text == null)
                throw new HyperlambdaException("[puppeteer.fill] requires a [text] child node");

            var selectorLiteral = JsonSerializer.Serialize(selector);
            var clearScript = $"if(document.querySelector({selectorLiteral})){{document.querySelector({selectorLiteral}).value = '';}}";
            await page.EvaluateExpressionAsync(clearScript);

            var options = new TypeOptions
            {
                Delay = PuppeteerHelpers.GetOptionalInt(input, "delay"),
            };

            await page.TypeAsync(selector, text, options);

            input.Clear();
            input.Value = null;
        }
    }
}
