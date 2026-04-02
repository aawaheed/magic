Workflow; Headless browser functions
WORKFLOW ==> headless-browser-functions

This workflow documents the available headless browser functions backed by PuppeteerSharp. These functions are low-level building blocks: you create a session, act on pages using the session id, and close the session when finished. Each function is implemented as a workflow under `/misc/workflows/workflows/browse/` and can be invoked directly through its function wrapper.

You can use `get-context` to search for functions on demand, for example by querying function metadata at runtime and filtering for names that start with `puppeteer-`.

If the user wants the browser to remember cookies, login state, or previous browsing state, use `puppeteer-connect` with a stable `user-data-dir` value and reuse the same directory in later sessions.

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

**NOTICE** - You can only open up maximum 5 sessions at the same time, but you can reuse sessions - So keep sessions open until user tells you to close it in case the user wants to continue the session. Remind the user to tell you to close the session when done.
