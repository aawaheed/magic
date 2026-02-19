/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.goto] slot for navigating to a URL.
    /// </summary>
    [Slot(Name = "puppeteer.goto")]
    public class Goto : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(signaler);
            var url = PuppeteerHelpers.GetRequiredValue(input, "puppeteer.goto");

            var timeout = PuppeteerHelpers.GetOptionalInt(input, "timeout");
            var waitUntilValue = PuppeteerHelpers.GetOptionalString(input, "wait-until");
            var waitUntil = PuppeteerHelpers.ParseWaitUntil(waitUntilValue);

            IResponse response;
            var options = new NavigationOptions
            {
                ReferrerPolicy = "strict-origin-when-cross-origin",
                Referer = GetOrigin(url),
            };

            if (timeout.HasValue && timeout.Value > 0)
                options.Timeout = timeout.Value;
            if (waitUntil.HasValue)
                options.WaitUntil = new[] { waitUntil.Value };

            response = await page.GoToAsync(url, options);

            input.Clear();
            input.Value = response?.Url ?? page.Url;
        }

        static string GetOrigin(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
                return null;

            return uri.GetLeftPart(UriPartial.Authority);
        }
    }
}
