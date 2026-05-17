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
    [Slot(
        Name = "puppeteer.content",
        Description = "Returns the current page HTML content",
        ValueType = "string",
        ValueKind = "puppeteer-session",
        RequiresScope = "puppeteer-session",
        ScopeProvider = "puppeteer.connect",
        Preconditions = "puppeteer-page-loaded",
        ValueDescription = "Puppeteer session ID",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "string",
        ReturnsKind = "html,text,formattable-value",
        ReturnsDescription = "Resolves to the current page HTML content")]
    public class Content : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(input);
            var content = await page.GetContentAsync();
            input.Clear();
            input.Value = content;
        }
    }
}
