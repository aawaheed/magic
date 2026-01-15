
# Update training snippet

The following function allows you to update a training snippet given its ID. If the user wants to edit or modify a specific training snippet in your RAG/VSS database, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/update-training-snippet.hl]:
{
  "id": "[NUMERIC_VALUE]",
  "prompt": "[STRING_VALUE]",
  "completion": "[STRING_VALUE]"
}
___

Arguments;

- `id` is mandatory and the ID of the training snippet to update
- `prompt` is optional single sentence summary of completion
- `completion` is optional and the actual training data
