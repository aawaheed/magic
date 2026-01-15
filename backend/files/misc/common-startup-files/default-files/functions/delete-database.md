
# Delete database

Deletes the SQLite database specified as [name].

If the user wants you to delete an SQLite database you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/delete-sqlite-database.hl]:
{
  "database": "[STRING_VALUE]"
}
___

Arguments:

* `database` is the mandatory argument being name of database. Notice, database must exist from before, and database name **SHOULD NOT** contain file suffix (.db), but only the name such as for instance 'crm' or 'erp'.

**IMPORTANT** - Warn the use that this action is **PERMANENT**, and have the user confirm before proceeding to delete the database.
