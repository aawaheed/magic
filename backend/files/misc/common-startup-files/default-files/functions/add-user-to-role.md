
# Add user to role

If the user asks you to add a user to a role then end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/users_roles/add-to-role.hl]:
{
  "username": "[STRING_VALUE]",
  "role": "[STRING_VALUE]"
}
___

Arguments:

* `username` is mandatory
* `role` is mandatory

Notice, both the rols and the user must exist from before. If you're not sure if they do, you can use the "list-roles" function and the "list-users" function to check.
