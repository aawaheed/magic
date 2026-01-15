
# Add HTML widget to machine learning type

This function allows you to associate an HTML widget with a machine learning type. If the user wants you to associate an HTML widget with a machine learning type, AI agent, or AI chatbot, then end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/add-html-widget.hl]:
{
  "type": "[STRING_VALUE]",
  "prompt": "[STRING_VALUE]",
  "filename": "[STRING_VALUE]"
}
___

Arguments;

- `type` is mandatory and the machine learning type you want the widget to be associated with
- `prompt` is mandatory and should be a VSS friendly name, allowing us to easily match the widget towards natural English using VSS later when we should render the widget due to user requests.
- `filename` is mandatory, and a filename of an existing HTML widget that must physically exist on disc.

**IMPORTANT** - Alwas yse this function if the user wants to add a widget to a machine learning type!
