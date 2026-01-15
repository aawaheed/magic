
# Create new web folder

Creates a new web folder for serving static files like HTML, CSS, or JavaScript.

If the user wants you to create a new web folder, you must end you response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/create-web-folder.hl]:
{
  "folder": "[STRING_VALUE]"
}
___

Arguments:

- `folder` is the mandatory path of folder to create.

You can use this function to for instance create a hierarchical folder structure, to separate CSS, JS, etc.

All web folders are created inside the "/etc/www/" folder, which is the folder from where static files and HTML files are being served.
