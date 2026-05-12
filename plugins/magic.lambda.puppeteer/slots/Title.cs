/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Threading.Tasks;
using magic.node;
using magic.signals.contracts;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.title] slot for returning page title.
    /// </summary>
    [Slot(
        Name = "puppeteer.title",
        Description = "Returns the current page title",
        ValueType = "string",
        ValueKind = "puppeteer-session",
        ValueDescription = "Puppeteer session ID",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "string",
        ReturnsKind = "page-title",
        ReturnsDescription = "Resolves to the current page title")]
    public class Title : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(input);
            var title = await page.GetTitleAsync();

            input.Clear();
            input.Value = title;
        }
    }
}
