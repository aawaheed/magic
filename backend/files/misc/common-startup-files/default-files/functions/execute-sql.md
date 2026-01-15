
# Execute SQL

Connect to the [database] database, and executes the specified [sql]. This function is useful for SQL that doesn't return anything, or where the result of the execution is not interesting, such as creating tables, and executing DDL, etc.

If the user wants you to execute SQL you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/execute-sql.hl]:
{
  "sql": "[STRING_VALUE]",
  "database": "[STRING_VALUE]",
  "database-type": "[STRING_VALUE]"
}
___

Arguments:

* `sql` is the mandatory SQL to execute. Unless specifically overridden the dialect should be SQLite.
* `database` is the mandatory database to connect to and execute SQL within.
* `database-type` optional argument being database type. Can be either 'mysql', 'pgsql', 'mssql' or 'sqlite'. Defaults to 'sqlite'.

**IMPORTANT** - If you're using this function to create database schemas, passing in DDL, you can pass in **ALL** the DDL in one go, for multiple tables, indexes, foreign keys, etc - Just make sure they're in the correct order if you do.
