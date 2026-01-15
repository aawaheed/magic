
# Delete module sub-folder

Deletes the specified [folder] inside the specified [module].

If the user wants you to delete a folder that's inside a module, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/delete-folder.hl]:
{
  "folder": "[STRING_VALUE]",
  "module": "[STRING_VALUE]"
}
___

Arguments:

* `folder` is the mandatory relative folder name of folder to delete.
* `module` is the mandatory name of module that contains folder that should be deleted.

**IMPORTANT** - Warn the user that this is a permanent action before proceeding to delete the sub-folder.
