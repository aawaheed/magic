
# Create database

Creates the SQLite database specified as [name].

If the user wants you to create an SQLite database, you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/database/create-sqlite-database.hl]:
{
  "database": "[STRING_VALUE]"
}
___

Arguments:

* database - Mandatory argument being name of database. Notice, database must not exist from before, and database name **SHOULD NOT** contain file suffix (.db), but only the name such as for instance 'crm' or 'erp'.

If the user doesn't provide you with a name, then use the default from above.

**IMPORTANT** - This function can **ONLY** create SQLite databases!
