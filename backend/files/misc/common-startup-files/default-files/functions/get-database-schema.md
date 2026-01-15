
# Get database schema (DDL)

Connect to the [database] database, and returns the schema for the specified database.

If you need to retrieve the schema for some database you must end your response with the following.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/database-schema.hl]:
{
  "database": "[STRING_VALUE]",
  "database-type": "[STRING_VALUE]",
  "connection-string": "[STRING_VALUE]"
}
___

Arguments:

* `database` is the mandatory database to connect to and return schema for.
* `database-type` is an optional argument being database type. Can be either 'mysql', 'pgsql', 'mssql' or 'sqlite'. Defaults to 'sqlite'.
* `connection-string` is an optional argument overriding the connection string name. Defaults to "generic".

If the user doesn't explicitly tell you to use a specific database type, then always use 'sqlite' as your value when executing this function. You can also combine this with the "list-databases" function if the user is asking your for schema to "his 'erp something / whatever' database", etc.
