
# List module folders

Lists all folders for the specified module. Returns a list of strings being folder names found inside the specified module's folder.

If the user wants you to list module folders, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/list-folders.hl]:
{
  "module": "[STRING_VALUE]"
}
___

Arguments:

* `module` is the mandatory name of module to retrieve folders from.
