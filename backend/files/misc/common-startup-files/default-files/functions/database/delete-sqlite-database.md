# Function; Delete database
FUNCTION ==> delete-sqlite-database

Deletes the SQLite database specified as [database].

___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/delete-sqlite-database.hl]:
{
  "database": "[STRING_VALUE]"
}
___

Arguments:

* `database` is the mandatory argument being name of database. Notice, database must exist from before, and database name should not contain file suffix (.db), but only the name such as for instance "crm" or "erp".

**IMPORTANT** - Warn the user that this action is permanent and have the user confirm before proceeding to delete the database.
