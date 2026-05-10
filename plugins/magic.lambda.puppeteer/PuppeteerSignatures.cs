/*
 * Magic Cloud, copyright (c) 2026 Thomas Hansen.
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.puppeteer.signatures
{
    public abstract class PuppeteerSignature : ISlotSignature
    {
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        public virtual IEnumerable<SlotConstraint> Constraints => new SlotConstraint[0];

        protected static SlotChild Option(string name, string type, string description, bool required = false, string defaultValue = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                DefaultValue = defaultValue,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }

        protected static SlotChild Args(string name, string description)
        {
            return new SlotChild
            {
                Name = name,
                Type = "string|lambda",
                Description = description,
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
                Children =
                {
                    new SlotChild
                    {
                        Name = ".",
                        Type = "string",
                        Description = "Argument value",
                        Required = false,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            };
        }
    }

    public class PuppeteerConnectSignature : PuppeteerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("timeout-minutes", "int", "Idle timeout in minutes"),
            Option("max-lifetime-minutes", "int", "Maximum session lifetime in minutes"),
            Option("headless", "bool", "Whether the browser should run headless", defaultValue: "true"),
            Option("timeout", "int", "Browser launch timeout in milliseconds"),
            Args("args", "Browser launch arguments"),
            Option("user-data-dir", "string", "Browser user data directory"),
            Option("executable", "string", "Browser executable path"),
            Option("executable-path", "string", "Browser executable path"),
        };
    }

    public class PuppeteerSelectorSignature : PuppeteerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("selector", "string", "CSS selector", true),
        };
    }

    public class PuppeteerClickSignature : PuppeteerSelectorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("selector", "string", "CSS selector", true),
            Option("button", "string", "Mouse button to click", defaultValue: "left"),
            Option("click-count", "int", "Number of clicks"),
            Option("delay", "int", "Delay in milliseconds between mouse down and up"),
        };
    }

    public class PuppeteerTextSignature : PuppeteerSelectorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("selector", "string", "CSS selector", true),
            Option("text", "string", "Text to send"),
            Option("config-key", "string", "Configuration key resolving the text to send"),
            Option("delay", "int", "Delay in milliseconds between key presses"),
        };

        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            new SlotConstraint
            {
                Kind = SlotConstraintKind.ExactlyOneOf,
                Description = "Provide either [text] or [config-key]",
                Values = { "text", "config-key" },
            },
        };
    }

    public class PuppeteerGotoSignature : PuppeteerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("url", "string", "URL to navigate to", true),
            Option("timeout", "int", "Navigation timeout in milliseconds"),
            Option("wait-until", "string", "Navigation completion condition"),
        };
    }

    public class PuppeteerWaitForSelectorSignature : PuppeteerSelectorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("selector", "string", "CSS selector", true),
            Option("timeout", "int", "Wait timeout in milliseconds"),
            Option("visible", "bool", "Wait until selector is visible"),
            Option("hidden", "bool", "Wait until selector is hidden"),
        };
    }

    public class PuppeteerWaitForUrlSignature : PuppeteerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("url", "string", "URL pattern to wait for", true),
            Option("timeout", "int", "Wait timeout in milliseconds"),
        };
    }

    public class PuppeteerEvaluateSignature : PuppeteerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("expression", "string", "JavaScript expression or function", true),
            Args("args", "Arguments passed to the JavaScript function"),
        };
    }

    public class PuppeteerSelectSignature : PuppeteerSelectorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("selector", "string", "CSS selector", true),
            Args("values", "Option values to select"),
        };
    }

    public class PuppeteerScreenshotSignature : PuppeteerSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("filename", "string", "Destination filename", true),
            Option("full-page", "bool", "Whether to capture the full page", defaultValue: "false"),
            Option("type", "string", "Image type"),
            Option("quality", "int", "JPEG/WebP image quality"),
        };
    }

    public class PuppeteerPressSignature : PuppeteerSelectorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("selector", "string", "CSS selector", true),
            Option("key", "string", "Key to press"),
            Option("delay", "int", "Delay in milliseconds between key down and up"),
        };
    }
}
