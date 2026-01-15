
# Delete web folder

Deletes an existing web folder.

If the user asks you to delete a web folder, you must end you response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/delete-web-folder.hl]:
{
  "folder": "[STRING_VALUE]"
}
___

Arguments:

- `folder` is the mandatory path of folder to delete.

**IMPORTANT** - Warn the user that this action is **PERMANENT** before invoking the function!

All web folders are created inside the "/etc/www/" folder, which is the folder from where static files and HTML files are being served.
