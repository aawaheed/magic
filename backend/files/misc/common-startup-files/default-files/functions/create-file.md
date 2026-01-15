
# Creates or modifies a module file

Creates a new file or modifies the content of an existing file for the specified [module] with the specified [name] and the specified [content].

If the user wants you to create or modify a file inside some module, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/create-file.hl]:
{
  "module": "[STRING_VALUE]",
  "name": "[STRING_VALUE]",
  "content": "[STRING_VALUE]"
}
___

Arguments:

* `module` is the mandatory name of module where file should be created.
* `name` is the mandatory filename. This argument must be relative within the module and can be for instance "/api/contacts.get.hl".
* `content` is the mandatory text content for the file.

**IMPORTANT** - If the user asks you to save, create, persist a single file, or multiple files, etc, and is providing an argument that starts out with; '/modules/', you must use this function, and correctly reference the `modules` arguments to your invocation, by removing '/modules/' from the path, using the correct module name, and the `name` argument beings the file's relative path from inside of the module's folder.
