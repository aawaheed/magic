Workflow; Headless browser functions
WORKFLOW ==> headless-browser-functions

This workflow documents the available headless browser functions backed by PuppeteerSharp. These functions are low-level building blocks: you create a session, act on pages using the session id, and close the session when finished. Each function is implemented as a workflow under `/misc/workflows/workflows/browse/` and can be invoked directly through its function wrapper.

You can use `get-context` to search for functions on demand, for example by querying function metadata at runtime and filtering for names that start with `puppeteer-`.

Available functions:

- `puppeteer-connect` - Creates a new headless browser session and returns a session id
- `puppeteer-close` - Closes an existing session
- `puppeteer-goto` - Navigates a session to a URL
- `puppeteer-wait-for-url` - Waits until the current URL matches a value
- `puppeteer-wait-for-selector` - Waits for a selector to appear (optionally visible/hidden)
- `puppeteer-click` - Clicks a selector
- `puppeteer-type` - Types text into a selector
- `puppeteer-fill` - Clears and types text into a selector
- `puppeteer-press` - Presses a key on a selector
- `puppeteer-select` - Selects option values in a `<select>` element
- `puppeteer-content` - Returns the current page HTML
- `puppeteer-title` - Returns the current page title
- `puppeteer-url` - Returns the current page URL
- `puppeteer-screenshot` - Saves a screenshot to disk
- `puppeteer-evaluate` - Evaluates JavaScript in the page
