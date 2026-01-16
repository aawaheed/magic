
# Create user

This function allows you to create a new user in the system.

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
