
# Create user

If the user asks you to create a user then end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/users/create-user.hl]:
{
  "username": "[STRING_VALUE]",
  "password": "[STRING_VALUE]",
  "name": "[STRING_VALUE]",
  "email": "[STRING_VALUE]"
}
___

Arguments:

* `username` is mandatory
* `password` is mandatory, and will be cryptographically hashed before saved
* `name` is optional
* `email` is optional
