# Function; Puppeteer type
FUNCTION ==> puppeteer-type

Types text into a selector.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/browse/puppeteer-type.hl]:
{
  "session_id": "[STRING_VALUE]",
  "selector": "[STRING_VALUE]",
  "text": "[STRING_VALUE]",
  "delay": 25
}
___

Arguments:

* `session_id` is mandatory and must be a valid Puppeteer session id
* `selector` is mandatory and the CSS selector to type into
* `text` is mandatory and the text to type
* `delay` is optional and is the delay between key presses in milliseconds
