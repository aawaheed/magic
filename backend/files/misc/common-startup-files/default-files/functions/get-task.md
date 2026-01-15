
# Get task

The following function can be used to get a specific task, including its Hyperlambda.

If the user wants to inspect or view a task or job, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/tasks/get-task.hl]:
{
  "name": "[STRING_VALUE]"
}
___

Arguments;

- `name` is mandatory name or ID of task to retrieve
