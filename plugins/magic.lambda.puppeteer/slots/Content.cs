/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Threading.Tasks;
using magic.node;
using magic.signals.contracts;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.content] slot for returning page HTML content.
    /// </summary>
    [Slot(Name = "puppeteer.content")]
    public class Content : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(signaler);
            var content = await page.GetContentAsync();
            input.Clear();
            input.Value = content;
        }
    }
}
