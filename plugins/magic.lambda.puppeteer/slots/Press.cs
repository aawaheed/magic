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
    /// [puppeteer.press] slot for pressing a key on a selector.
    /// </summary>
    [Slot(Name = "puppeteer.press")]
    public class Press : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(signaler);
            var selector = PuppeteerHelpers.GetRequiredValue(input, "puppeteer.press");
            var key = PuppeteerHelpers.GetOptionalString(input, "key");
            if (string.IsNullOrWhiteSpace(key))
                throw new HyperlambdaException("[puppeteer.press] requires a [key] child node");

            var options = new PressOptions
            {
                Delay = PuppeteerHelpers.GetOptionalInt(input, "delay"),
            };

            await page.FocusAsync(selector);
            await page.Keyboard.PressAsync(key, options);

            input.Clear();
            input.Value = null;
        }
    }
}
