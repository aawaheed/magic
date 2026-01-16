
# Save file

Saves a new file or overwrites an existing file with the specified [content]. If the user wants you to create, modify, or save a file, then you must use this function.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/create-file.hl]:
{
  "filename": "[STRING_VALUE]",
  "content": "[STRING_VALUE]"
}
___

## Arguments

* `filename` is the mandatory filename and must be a fully qualified path, such as for instance "/modules/foo/bar.hl".
* `content` is the mandatory text content for the file.

Notice, you can only save files in the "/etc/" and "/modules/" folders.

If you need to create a temporary file, you can save this to "/etc/tmp/".
