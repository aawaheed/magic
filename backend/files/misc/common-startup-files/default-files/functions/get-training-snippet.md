
# Get training snippet

The following function returns a single AI chatbot/AI agent/machine learning type training snippet and can be used if user asks to see the details for a specific snippet, or if you need it for some reasons. If the user wants to see one specific training snippet from your RAG/VSS database, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/get-training-snippet.hl]:
{
  "id": "[NUMERIC_VALUE]"
}
___

Arguments;

- `id` is mandatory and the ID of the snippet to return
