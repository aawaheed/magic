# INFO; Headless Browser Generator Example Prompts

Magic can use Puppeteer as a headless browser to automate web browsing. Below are some example prompts that should work if you run them through the Hyperlambda Generator to create Hyperlambda code using the Puppeteer slots from Magic.

- "Create a headless browser, open 'ainiro.io', wait until the page has loaded, and create a screenshot and save to '/etc/tmp.png'. When done, make sure you close the browser session."
- "Use a headless browser to go to 'ainiro.io/contact-us', wait for the '#name' selector to be visible, fill in '#name' with 'Thomas', '#email' with 'thomas@gaiasoul.com', and click the '#submit' button. Wait for two seconds, and close the headless browser instance."
- "Go to www.hubspot.com using puppeteer and retrieve the HTML, transform it to markdown, and return the result."
- "Go to www.salesforce.com using a headless browser and retrieve the HTML, then traverse the HTML for all hyperlinks, and return their anchor text and absolute URLs. Make sure you close the browser session when done."
- "Go to www.google.com using a headless browser and return the browser session id to the caller as 'browser_session'"

Notice, the headless browser is using a lot of memory, so for most prompts you'd either want to return the browser session to reuse it, and/or close it immediately to avoid it becomes 'dangling'. And you cannot open more than 5 browser sessions at the same time. If a browser session is not used for 15 minutes, it is automatically closed (by default, this can be overridden).
