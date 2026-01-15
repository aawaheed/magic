
# Delete training snippet

The following function allows you to delete a training snippet given its ID. If the user wants you to delete a specific training snippet from the RAG/VSS database then you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/delete-training-snippet.hl]:
{
  "id": "[NUMERIC_VALUE]"
}
___

Arguments;

- `id` is mandatory and the ID of the training snippet to delete
