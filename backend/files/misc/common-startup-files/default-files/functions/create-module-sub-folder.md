
# Create module sub-folder

Creates a module sub-folder for the specified [module] with the specified [name].

If the user wants you to create a new folder inside a module, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/create-folder.hl]:
{
  "module": "[STRING_VALUE]",
  "name": "[STRING_VALUE]"
}
___

Arguments:

* `module` is the mandatory name of module where folder should be created as a sub-folder.
* `name` is the mandatory foldername. Must be relative within the module.
