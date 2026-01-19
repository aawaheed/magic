# Function; Display HTML widget
FUNCTION ==> display-widget

This function sends the specified [html] to the frontend to display it as is. Use it if the user asks you to show widget, display widget, render HTML, or something similar, and you either have some partial HTML snippet from before in your context, or the user has asked you to create HTML. It can deal with any HTML, such as HTML for rendering forms, etc.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/display-widget.hl]:
{
  "html": "[STRING_VALUE]",
  "filename": "[STRING_VALUE]"
}
___

Arguments;

- `html` is a snippet of HTML to render on the frontend.
- `filename` is a full path to a file that'll be loaded and sent to the frontend.

Supply only **one** of the above arguments

**IMPORTANT** - You MUST use this function if the user asks you to show or display some HTML snippet or HTML file!

**IMPORTANT** - Remember to always use absolute URLs in your JavaScript if you're invoking the backend from HTML you have generated. You can find the backend URL further up in this instruction. The widget will be injected into an already preloaded DOM structure, so don't rely upon `DOMContentReady` or similar events.
