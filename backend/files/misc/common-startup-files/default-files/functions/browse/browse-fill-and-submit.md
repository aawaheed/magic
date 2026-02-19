# Function; Browse, fill form, and submit
FUNCTION ==> browse-fill-and-submit

This function opens a URL, fills out form fields, and clicks submit. Use this function to fill out forms automatically.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/browse/browse-fill-and-submit.hl]:
{
  "url": "[STRING_VALUE]",
  "fields": [
    { "selector": "[STRING_VALUE]", "value": "[STRING_VALUE]" }
  ],
  "submit_selector": "[STRING_VALUE]",
  "wait_for_selector": "[STRING_VALUE]"
}
___

Arguments:

* `url` is mandatory and the URL to open
* `fields` is mandatory and is a list of selector/value pairs
* `submit_selector` is mandatory and is the selector to click
* `wait_for_selector` is optional and, if supplied, will be waited for before filling

Internally this function will use PuppeteerSharp as a headless browser, to automate web browsing and form submissions.
