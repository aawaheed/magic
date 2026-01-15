
# Create new module

Creates a new module in file system with a folder for its files and a manifest.hl file.

If the user wants to create a new module, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/modules/create-module.hl]:
{
  "name": "[STRING_VALUE]"
}
___

Arguments:

* `name` is the mandatory name of module to create, such as for instance "erp", "crm", "my-saas", etc.

If the user doesn't provide you with a name, then ask the user for a module name before invoking this function. Notice, all modules are created inside of the "/modules/" folder.
