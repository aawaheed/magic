/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.page] slot for creating a new page scoped to its child lambda.
    /// </summary>
    [Slot(Name = "puppeteer.page")]
    public class Page : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            if (!input.Children.Any(x => x.Name == ".lambda"))
                throw new HyperlambdaException("[puppeteer.page] requires a [.lambda] child");

            var browser = PuppeteerHelpers.RequireBrowser(signaler);
            IPage page = null;

            try
            {
                page = await browser.NewPageAsync();

                var lambda = PuppeteerHelpers.GetLambda(input);

                await signaler.ScopeAsync(
                    "puppeteer.page",
                    page,
                    async () => await signaler.SignalAsync("eval", lambda));

                input.Value = null;
            }
            finally
            {
                if (page != null && !page.IsClosed)
                {
                    try
                    {
                        await page.CloseAsync();
                    }
                    catch
                    {
                        // Best effort shutdown; ignore if already closed.
                    }
                }
            }
        }
    }
}
