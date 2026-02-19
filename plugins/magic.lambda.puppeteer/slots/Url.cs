/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using magic.node;
using magic.signals.contracts;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.url] slot for returning current URL.
    /// </summary>
    [Slot(Name = "puppeteer.url")]
    public class Url : ISlot
    {
        public void Signal(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(signaler);

            input.Clear();
            input.Value = page.Url;
        }
    }
}
