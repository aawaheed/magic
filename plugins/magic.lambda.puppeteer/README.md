---
title: magic.lambda.puppeteer
---

The magic.lambda.puppeteer project provides headless Chromium automation slots for Magic using PuppeteerSharp.
All slots are scoped, following the "using" pattern. This means you open a browser scope with **[puppeteer.connect]**
and a page scope with **[puppeteer.page]**, and all other slots require those scopes to exist. There is no explicit
close slot. Scopes are disposed deterministically when their lambda completes.

More specifically this project contains the following slots.

* __[puppeteer.connect]__ - Launches Chromium and scopes a browser instance for child lambda
* __[puppeteer.page]__ - Creates a page and scopes it for child lambda
* __[puppeteer.goto]__ - Navigates to a URL
* __[puppeteer.wait-for-url]__ - Waits until the page URL matches
* __[puppeteer.wait-for-selector]__ - Waits until a selector appears
* __[puppeteer.wait-for-timeout]__ - Sleeps for N milliseconds
* __[puppeteer.click]__ - Clicks a selector
* __[puppeteer.type]__ - Types text into a selector
* __[puppeteer.fill]__ - Clears and types text into a selector
* __[puppeteer.press]__ - Presses a key on a selector
* __[puppeteer.select]__ - Selects option values from a selector
* __[puppeteer.content]__ - Returns page HTML
* __[puppeteer.title]__ - Returns page title
* __[puppeteer.url]__ - Returns current URL
* __[puppeteer.screenshot]__ - Saves a screenshot to disk
* __[puppeteer.evaluate]__ - Evaluates a JavaScript expression in the page

## Slot arguments

Arguments are provided as child nodes to the slot. Slots that require a **[.lambda]** child are marked.

**[puppeteer.connect]** (requires **[.lambda]**)
* `headless` - Boolean. Launch Chromium in headless mode. Defaults to true.
* `executable` - Full path to Chromium/Chrome binary.
* `executable-path` - Alias for `executable`.
* `timeout` - Launch timeout in milliseconds.
* `user-data-dir` - Directory for Chromium user data.
* `args` - Additional Chromium arguments. Each child value is one argument string.

**[puppeteer.page]** (requires **[.lambda]**)
* No arguments. The scoped page is created and used by child lambda.

**[puppeteer.goto]**
* Slot value - URL to navigate to.
* `timeout` - Navigation timeout in milliseconds.
* `wait-until` - One of `load`, `domcontentloaded`, `networkidle0`, `networkidle2`.

**[puppeteer.wait-for-url]**
* Slot value - URL string to wait for.
* `timeout` - Timeout in milliseconds.

**[puppeteer.wait-for-selector]**
* Slot value - CSS selector to wait for.
* `timeout` - Timeout in milliseconds.
* `visible` - Boolean. Require element to be visible.
* `hidden` - Boolean. Require element to be hidden.

**[puppeteer.wait-for-timeout]**
* Slot value - Sleep duration in milliseconds.

**[puppeteer.click]**
* Slot value - CSS selector to click.
* `button` - Mouse button: `left`, `middle`, or `right`.
* `click-count` - Number of clicks.
* `delay` - Delay between down and up in milliseconds.

**[puppeteer.type]**
* Slot value - CSS selector to type into.
* `text` - Text to type.
* `delay` - Delay between key presses in milliseconds.

**[puppeteer.fill]**
* Slot value - CSS selector to fill.
* `text` - Text to type after clearing.
* `delay` - Delay between key presses in milliseconds.

**[puppeteer.press]**
* Slot value - CSS selector to focus.
* `key` - Key name (for example `Enter`).
* `delay` - Delay in milliseconds.

**[puppeteer.select]**
* Slot value - CSS selector for a `<select>` element.
* `values` - Values to select. Provide as children or a comma-separated string.

**[puppeteer.content]**
* No arguments. Returns page HTML.

**[puppeteer.title]**
* No arguments. Returns page title.

**[puppeteer.url]**
* No arguments. Returns current URL.

**[puppeteer.screenshot]**
* Slot value - Output file path.
* `full-page` - Boolean. Capture full scrollable page.
* `type` - `png` or `jpeg`.
* `quality` - JPEG quality 0-100 (only for `jpeg`).

**[puppeteer.evaluate]**
* Slot value - JavaScript expression string.
* `args` - Optional arguments for JS function invocation. Each child value is one argument.

## How to use [puppeteer.connect] and [puppeteer.page]

The two scope slots wrap all other operations. A minimal example looks like this.

```
puppeteer.connect
   .lambda
      puppeteer.page
         .lambda
            puppeteer.goto:"https://ainiro.io"
            puppeteer.title
            puppeteer.screenshot:/etc/tmp/example.png
               full-page:true
```

Both **[puppeteer.connect]** and **[puppeteer.page]** require a **[.lambda]** child.

You can pass optional launch arguments to **[puppeteer.connect]**.

```
puppeteer.connect
   headless:true
   executable:/Applications/Google Chrome.app/Contents/MacOS/Google Chrome
   timeout:30000
   args
      .:--no-sandbox
      .:--disable-dev-shm-usage
   .lambda
      puppeteer.page
         .lambda
            puppeteer.goto:"https://ainiro.io"
```

## How to use [puppeteer.wait-for-selector]

Use this slot to block until a selector appears in the DOM, optionally requiring it to be visible.

```
puppeteer.connect
   .lambda
      puppeteer.page
         .lambda
            puppeteer.goto:"https://ainiro.io"
            puppeteer.wait-for-selector:#create_bot_form
               visible:true
```

## How to use [puppeteer.type] and [puppeteer.press]

These slots allow you to type and press keys against specific selectors.

```
puppeteer.connect
   .lambda
      puppeteer.page
         .lambda
            puppeteer.goto:"https://ainiro.io/login"
            puppeteer.type:"#username"
               text:demo
            puppeteer.type:"#password"
               text:secret
            puppeteer.press:"#password"
               key:Enter
```

## How to use [puppeteer.screenshot]

The screenshot slot writes to a file path relative to your Magic files root.

```
puppeteer.connect
   .lambda
      puppeteer.page
         .lambda
            puppeteer.goto:"https://ainiro.io"
            puppeteer.screenshot:"/etc/tmp/example.png"
               full-page:true
               type:png
```

## Browser automation

The following code submits our _"contact us"_ form, bypassing our CAPTCHA.

```
puppeteer.connect
   .lambda
      puppeteer.page
         .lambda
            puppeteer.goto:"https://ainiro.io/contact-us"
            puppeteer.wait-for-selector:#name
               visible:true
            puppeteer.type:#name
               text:Thomas Hansen Automation
            puppeteer.type:#email
               text:thomas@gaiasoul.com
            puppeteer.type:#info
               text:Automatically sent email
            puppeteer.click:#submit_contact_form_button
            puppeteer.wait-for-timeout:3000
```

The point about the above code is that during submission of the form, we have to wait some 3 seconds for the CAPTCHA lib to do its thing, beofre we allow for the _"scope"_ to be destroyed.
