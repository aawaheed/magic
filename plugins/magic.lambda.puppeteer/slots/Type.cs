/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;
using PuppeteerSharp.Input;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.type] slot for typing into a selector.
    /// </summary>
    [Slot(Name = "puppeteer.type")]
    public class Type : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(input);
            var selector = PuppeteerHelpers.GetRequiredString(input, "selector");
            var text = PuppeteerHelpers.GetOptionalString(input, "text");
            if (text == null)
                throw new HyperlambdaException("[puppeteer.type] requires a [text] child node");

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
