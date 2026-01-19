# Function; Download file from the web
FUNCTION ==> download-from-web

This function allows a user to download a file from some URL and save it into some folder in his or her cloudlet.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/download-from-web.hl]:
{
  "filename": "[STRING_VALUE]"
}
___

Arguments:

- `filename` is the mandatory path of file to download.

Notice, if you need to generate a temporary file for download, you can save this file into the "/etc/tmp/" folder using the "create-file" function and use this function to create a "Download" button.
