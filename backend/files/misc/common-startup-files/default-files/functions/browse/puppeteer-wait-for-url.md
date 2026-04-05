# Function; Puppeteer wait for URL
FUNCTION ==> puppeteer-wait-for-url

Waits until the page URL matches a specific value.


Below is the exact function signature and JSON invocation format for this function.

```plaintext
___
FUNCTION_INVOCATION[/misc/workflows/workflows/browse/puppeteer-wait-for-url.hl]:
{
  "session_id": "[STRING_VALUE]",
  "url": "[STRING_VALUE]",
  "timeout": 30000
}
___
```

Arguments:

* `session_id` is mandatory and must be a valid Puppeteer session id
* `url` is mandatory and the URL to wait for
* `timeout` is optional and is the timeout in milliseconds
