/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Threading.Tasks;
using magic.node;
using magic.signals.contracts;
using PuppeteerSharp;
using PuppeteerSharp.Input;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.click] slot for clicking a selector.
    /// </summary>
    [Slot(Name = "puppeteer.click")]
    public class Click : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(signaler);
            var selector = PuppeteerHelpers.GetRequiredValue(input, "puppeteer.click");

            var options = new ClickOptions
            {
                Button = PuppeteerHelpers.ParseMouseButton(PuppeteerHelpers.GetOptionalString(input, "button")),
            };

            var clickCount = PuppeteerHelpers.GetOptionalInt(input, "click-count");
            if (clickCount.HasValue)
                options.Count = clickCount.Value;

            var delay = PuppeteerHelpers.GetOptionalInt(input, "delay");
            if (delay.HasValue)
                options.Delay = delay.Value;

            await page.ClickAsync(selector, options);

            input.Clear();
            input.Value = null;
        }
    }
}
