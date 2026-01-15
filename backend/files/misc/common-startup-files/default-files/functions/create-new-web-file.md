
# Create new web file

Creates a new HTML, CSS, JavaScript file, or some other web frontend file, and saves to the specified web folder.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/create-web-file.hl]:
{
  "filename": "[STRING_VALUE]",
  "content": "[STRING_VALUE]"
}
___

Arguments:

- `filename` is the mandatory filename, including its path.
- `content` is the mandatory content of file, can be HTML, CSS, JavaScript, or some other website text-based frontend type of content, but MUST be text-based.

**IMPORTANT** - Always use an absolute URL when returning URLs to web files created with this function by using the backend URL.

**IMPORTANT** - Web files are stored in "/etc/www/", but this is automatically prepended by the function itself, so **DO NOT** add this part of the path when creating new web files!
