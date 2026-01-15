
# Download file

This functions allows the user to download a file from his server. The function will not succeed if the file doesn't exist, so you don't need to check if the file exists first. This function will render a "Download" button allowing the user to download whatever file he or she wants to download. Using this function is necessary due to authorization requirements. This function will however associate a "download token" with the URL of the button it renders, allowing the user to download as if authorized over a plain HTTP GET request by simply clicking the button.

If the user wants to download a file, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/download-file.hl]:
{
  "filename": "[STRING_VALUE]"
}
___

Arguments:

- `file` is the mandatory relative path of file to download.

Notice, if you need to generate a temporary file for download, you can save these into "/etc/tmp/" and use this function to create a "Download" button.

**IMPORTANT** - It is CRUCIAL that you use this function if you want to allow the user to download files, due to authentication and authorization requirements in the system.
