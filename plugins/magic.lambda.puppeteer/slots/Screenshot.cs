/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System;
using System.IO;
using System.Threading.Tasks;
using magic.node;
using magic.node.contracts;
using magic.node.extensions;
using magic.signals.contracts;
using PuppeteerSharp;

namespace magic.lambda.puppeteer
{
    /// <summary>
    /// [puppeteer.screenshot] slot for saving a screenshot to disk.
    /// </summary>
    [Slot(Name = "puppeteer.screenshot")]
    public class Screenshot : ISlotAsync
    {
        readonly IRootResolver _rootResolver;

        public Screenshot(IRootResolver rootResolver)
        {
            _rootResolver = rootResolver;
        }

        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            var page = PuppeteerHelpers.RequirePage(signaler);
            var filename = PuppeteerHelpers.GetRequiredValue(input, "puppeteer.screenshot");
            var fullPath = _rootResolver.AbsolutePath(filename);

            var options = new ScreenshotOptions
            {
                FullPage = PuppeteerHelpers.GetOptionalBool(input, "full-page") ?? false,
            };

            var type = PuppeteerHelpers.GetOptionalString(input, "type");
            if (!string.IsNullOrWhiteSpace(type))
            {
                switch (type.Trim().ToLowerInvariant())
                {
                    case "png":
                        options.Type = ScreenshotType.Png;
                        break;
                    case "jpeg":
                    case "jpg":
                        options.Type = ScreenshotType.Jpeg;
                        break;
                    default:
                        throw new HyperlambdaException("[type] must be 'png' or 'jpeg'");
                }
            }

            var quality = PuppeteerHelpers.GetOptionalInt(input, "quality");
            if (quality.HasValue)
                options.Quality = quality.Value;

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            await page.ScreenshotAsync(fullPath, options);

            input.Clear();
            input.Value = _rootResolver.RelativePath(fullPath);
        }
    }
}
