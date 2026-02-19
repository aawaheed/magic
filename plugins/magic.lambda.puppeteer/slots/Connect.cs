/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.connect] slot for launching a Chromium browser instance scoped to its child lambda.
    /// </summary>
    [Slot(Name = "puppeteer.connect")]
    public class Connect : ISlotAsync
    {
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            if (!input.Children.Any(x => x.Name == ".lambda"))
                throw new HyperlambdaException("[puppeteer.connect] requires a [.lambda] child");

            var launchOptions = BuildLaunchOptions(input);
            IBrowser browser = null;
            IPage page = null;

            try
            {
                browser = await Puppeteer.LaunchAsync(launchOptions);
                page = await browser.NewPageAsync();

                var lambda = PuppeteerHelpers.GetLambda(input);

                await signaler.ScopeAsync(
                    "puppeteer.browser",
                    browser,
                    async () => await signaler.ScopeAsync(
                        "puppeteer.page",
                        page,
                        async () => await signaler.SignalAsync("eval", lambda)));

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
                if (browser != null && !browser.IsClosed)
                {
                    try
                    {
                        await browser.CloseAsync();
                    }
                    catch
                    {
                        // Best effort shutdown; ignore if already closed.
                    }
                }
            }
        }

        static LaunchOptions BuildLaunchOptions(Node input)
        {
            var headless = PuppeteerHelpers.GetOptionalBool(input, "headless") ?? true;
            var executablePath = GetExecutablePath(input);
            var timeout = PuppeteerHelpers.GetOptionalInt(input, "timeout");
            var userDataDir = PuppeteerHelpers.GetOptionalString(input, "user-data-dir");
            var argsNode = input.Children.FirstOrDefault(x => x.Name == "args");

            var options = new LaunchOptions
            {
                Headless = headless,
                ExecutablePath = executablePath,
            };

            if (timeout.HasValue && timeout.Value > 0)
                options.Timeout = timeout.Value;

            if (!string.IsNullOrWhiteSpace(userDataDir))
                options.UserDataDir = userDataDir;

            var args = PuppeteerHelpers.GetArgs(argsNode).ToArray();
            if (args.Length > 0)
                options.Args = args;

            return options;
        }

        static string GetExecutablePath(Node input)
        {
            var path = PuppeteerHelpers.GetOptionalString(input, "executable")
                ?? PuppeteerHelpers.GetOptionalString(input, "executable-path")
                ?? Environment.GetEnvironmentVariable("PUPPETEER_EXECUTABLE_PATH")
                ?? "/usr/bin/chromium";

            return path;
        }
    }
}
