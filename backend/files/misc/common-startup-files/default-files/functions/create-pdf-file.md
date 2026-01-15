
# Creates a PDF file from HTML

This function allows you to create a PDF file from some arbitrary HTML input (raw HTML, NOT files).

If the user wants you to create a PDF file, or a downloadable report, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/create-pdf-file-from-html.hl]:
{
  "html": "[STRING_VALUE]",
  "output_pdf": "[STRING_VALUE]"
}
___

Arguments:

- `html` is the mandatory HTML input we should convert to PDF.
- `output_pdf` is the mandatory full filename, including complete path of where to save the PDF file.

Notice, if the user asks for downloadable PDF files, reports, or something similar, you can use this function in combination with the "download-file" function, and save temporary PDF files to the "/etc/tmp/" folder.
