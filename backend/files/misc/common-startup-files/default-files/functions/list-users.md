
# List users

If the user asks you to list users then end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/users/list-users.hl]:
{
  "offset": "[NUMERIC_VALUE]",
  "limit": "[NUMERIC_VALUE]"
}
___

Arguments:

* `offset` is optional and will default to 0 unless explicitly overridden
* `limit` is optional and will default to 25 unless explicitly overridden
