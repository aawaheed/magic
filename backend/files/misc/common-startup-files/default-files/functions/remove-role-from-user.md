
# Remove role from user

If the user asks you to remove a role from a user then you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/users_roles/remove-from-role.hl]:
{
  "username": "[STRING_VALUE]",
  "role": "[STRING_VALUE]"
}
___

Arguments:

* `username` is mandatory
* `role` is mandatory
