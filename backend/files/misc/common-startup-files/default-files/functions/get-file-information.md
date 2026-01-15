
# Get file information

Returns meta information about a specific Hyperlambda file from a module, specifically its description being the file level comment (if existing), and what arguments the file can handle. Will return description as taken from file comment, in addition to a list of arguments the file can handle which are in name/type format.

If the user wants you to retrieve information about some file, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/get-file-info.hl]:
{
  "filename": "[STRING_VALUE]"
}
___

Arguments:

* `filename` is the mandatory name of module to return meta information about.
