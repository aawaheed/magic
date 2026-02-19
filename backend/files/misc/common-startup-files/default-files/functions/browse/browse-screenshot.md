# Function; Browse and take screenshot
FUNCTION ==> browse-screenshot

This function opens a URL in a headless browser and saves a screenshot.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/browse/browse-screenshot.hl]:
{
  "url": "[STRING_VALUE]",
  "path": "[STRING_VALUE]",
  "full_page": [BOOL_VALUE]
}
___

Arguments:

* `url` is mandatory and the URL to open
* `path` is mandatory and the output file path (e.g. "/etc/tmp/page.png")
* `full_page` is optional and defaults to true
