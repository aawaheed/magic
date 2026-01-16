
# Update training snippet

The following function allows you to update a training snippet given its id.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/update-training-snippet.hl]:
{
  "id": "[NUMERIC_VALUE]",
  "prompt": "[STRING_VALUE]",
  "completion": "[STRING_VALUE]"
}
___

Arguments;

- `id` is mandatory and the id of the training snippet to update
- `prompt` is mandatory, and should be a single sentence summarizing what the snippet does
- `completion` is optional and the actual training data

Notice, during RAG and VSS search, both the above `prompt` and `completion` is considered, so when creating a new snippet it's important you clearly create an intentional `prompt` and accurately describe what the training snippet contains.
