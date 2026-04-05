# Function; List databases
FUNCTION ==> list-databases

Lists all databases in the system for the specified connection string and database type.


Below is the exact function signature and JSON invocation format for this function.

```plaintext
___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/list-databases.hl]:
{
  "database-type": "[STRING_VALUE]",
  "connection-string": "[STRING_VALUE]"
}
___
```

Arguments:

* `database-type` is an optional argument being database type. Can be either "mysql", "pgsql", "mssql" or "sqlite". Defaults to "sqlite".
* `connection-string` is an optional argument overriding the connection string name. Defaults to "generic".
