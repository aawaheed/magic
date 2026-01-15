
# List databases

Lists all databases in the system.

If the user wants you to list all databases in your system you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/list-databases.hl]:
{
  "database-type: "[STRING_VALUE]"
}
___

Arguments;

* `database-type` is an optional argument being database type. Can be either 'mysql', 'pgsql', 'mssql' or 'sqlite'. Defaults to 'sqlite'.
