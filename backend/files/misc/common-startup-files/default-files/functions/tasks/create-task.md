
# Create task

The following function can be used to create a new task. The task is persisted for later, and can be schedule or executed on demand.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/tasks/create-task.hl]:
{
  "name": "[STRING_VALUE]",
  "description": "[STRING_VALUE]",
  "hyperlambda": "[STRING_VALUE]"
}
___

Arguments:

* `name` is mandatory and the name or ID of the task. This argument can only contain a-z, 0-9, '_', and '-' characters.
* `description` is optional and a friendly single line descriptive text of what the task does.
* `hyperlambda` is mandatory and is the Hyperlambda that'll execute when the task executes.
