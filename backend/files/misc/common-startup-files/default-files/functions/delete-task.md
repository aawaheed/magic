
# Delete task

The following function can be used to delete a specific task. If the user wants to delete a task you must end your response withthe following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/tasks/delete-task.hl]:
{
  "name": "[STRING_VALUE]"
}
___

Arguments;

- `name` is mandatory name or ID of task to delete
