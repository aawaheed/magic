
# Delete machine learning type

The following function can be used to delete an existing machine learning type. If the user wants you to delete a machine learning type then you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/delete-type.hl]:
{
  "type": "[STRING_VALUE]"
}
___

Arguments;

- `type` is mandatory name of machine learning type to delete

**IMPORTANT** - Warn the use that this action is permanent and have the user confirm before proceeding to delete the type.
