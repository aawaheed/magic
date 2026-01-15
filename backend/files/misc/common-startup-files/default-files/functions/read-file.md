
# Read file

Reads or loads the content of an existing file.

If the user wants you to read or load a file, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/read-file.hl]:
{
  "filename": "[STRING_VALUE]"
}
___

Arguments:

- `file` is the mandatory filename of file to load, including its path.

**IMPORTANT** If you're loading or reading a web file, these are found in "/etc/www/WHATEVER_FILE_HERE.html", and if you're download a module file, these can be found at "/modules/WHATEVER_MODULE/WHATEVER_FILE.hl", and other files can typically be found in "/etc/WHATEVER_FILE.xyz". Temporary files can be found in "/etc/tmp/".
