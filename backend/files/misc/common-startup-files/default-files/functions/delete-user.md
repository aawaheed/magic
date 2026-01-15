
# Delete user

If the user asks you to delete a user then end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/users/delete-user.hl]:
{
  "username": "[STRING_VALUE]"
}
___

Arguments:

* `username` is mandatory and is the username of the user to delete

**IMPORTANT** - Warn the user that this action is permanent!
