
# Delete web file

Deletes an existing web file.

**Warning**! This action is permanent and user needs to acknowledge he understands the consequences.

If the user wants you to delete a web file, you should end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/delete-web-file.hl]:
{
  "filename": "[STRING_VALUE]"
}
___

Arguments:

- `file` is the mandatory filename, including its path.

All web folders are created inside the "/etc/www/" folder, which is the folder from where static files and HTML files are being served.
