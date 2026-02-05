# Function; Create file
FUNCTION ==> create-file

Creates a new file or overwrites an existing file with the specified [content]. If the user wants you to create, modify, or save a file, then you must use this function.

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

## Rules for where to save files

1. Always save normal HTML, CSS, and JavaScript files inside the "/etc/www/" folder.
2. If you need to create a temporary file, you can save this to "/etc/tmp/".
3. Always save hyperlambda files inside the "/modules/WHATEVER_MODULE/" folder, and make sure the module exists before you try to save files here. If the module doesn't exist, you can use the `create-module` function to create it.
4. Always save HTML widgets inside "/modules/WHATEVER_MODULE/widgets/", and make sure the folder exists before you try to save files here.
5. Always verify before you save a file that you're not saving placeholders such as `{{PLACEHOLDER_HERE}}`, etc.

Replace "WHATEVER_MODULE" above with an actualy module name.
