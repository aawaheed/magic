
# Delete module file

Deletes the specified [file] inside the specified [module].

If the user wants you to delete a module file, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/delete-file.hl]:
{
  "filename": "[STRING_VALUE]",
  "module": "[STRING_VALUE]"
}
___

Arguments:

* `file` is the mandatory relative filename of file to delete. Must be a relative path within the module.
* `module` is the mandatory name of module that contains file that should be deleted.

**IMPORTANT** - Warn the user that this is a permanent action before proceeding to delete the file.
