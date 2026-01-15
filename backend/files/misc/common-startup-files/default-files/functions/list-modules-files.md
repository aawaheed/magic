
# List module files

Lists all files for the specified module. Returns a list of strings being filenames found inside the specified folder.

If the user wants you to list all module files, you must end you response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/list-files.hl]:
{
  "module": "[STRING_VALUE]"
}
___

Arguments:

* `module` is the mandatory name of module to retrieve files from.
