# Function; Add widget to machine learning type
FUNCTION ==> add-html-widget

A widget is a small snippet of partial HTML that can be rendered inside an AI agent or an AI chatbot. This function allows you to associate an HTML widget with a machine learning type, AI chatbot, or AI agent.

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

**IMPORTANT** - Always use this function if the user wants to add a widget to a machine learning type.
