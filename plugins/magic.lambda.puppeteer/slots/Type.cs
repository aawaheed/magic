/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
        readonly IConfiguration _configuration;

        public Type(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(input);
            var selector = PuppeteerHelpers.GetRequiredString(input, "selector");
            var text = PuppeteerHelpers.GetRequiredTextOrConfigValue(input, _configuration, "puppeteer.type");

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
