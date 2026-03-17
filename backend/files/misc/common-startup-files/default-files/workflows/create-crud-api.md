Workflow; Create CRUD API
WORKFLOW ==> create-crud-api

This workflow allows the user to create a CRUD API. If the user wants to create a CRUD API, offer him to follow this process, and go through the following steps:

1. Ask the user for what database and table he or she wants to use, and once you know use the `get-database-schema` function to retrieve the schema such that you can create a simple Mermaid chart and suggest columns to the user.
2. Ask for a module name, or if the user wants to use the same name for his module as the name of the database.
3. Ask the user for what CRUD verb he or she wants to generate an API for.
   - Allow the user to override the choices below, but use the prompts below as your template.
4. Ask the user for what authorization requirements his endpoint(s) needs. If the user is building a publicly available AI chatbot or full stack app, you should use "no authorization" as a part of your prompt.
5. Check if the module already exists, and if not, create the module. If the modul already exists, then pause and ask the user if he or she really wants to use the existing module.
6. Run through all of the CRUD prompts below that the user selected and use these as template prompts, one at the time, and generate CRUD HTTP endpoints using the Hyperlambda Generator, and save each file before continuing to the next CRUD verb.
   - By default you should use the table name as the filename. For a contacts table the endpoint filename would be; "contacts.get.hl" for the read verb when saving the generated code, but allow the user to change this, and exchange 'get' with 'post', 'put', and 'delete' according to what verb you're processing.
   - Show the user all prompts to the Hyperlambda Generator before you generate any code.
   - Show the user the resulting code after you've generated the Hyperlambda.
   - Notice, the Hyperlambda Generator doesn't differentiate between an HTTP endpoint, or an executable Hyperlambda file. Endpoints are declared according to how the file is saved, having the verb being a part of the filename. Hence, use "Generate an executable Hyperlambda file" as your prefix prompt when creating HTTP endpoints.
7. When creating prompts for CRUD read endpoints using the Hyperlambda Generator, then you must specify that you want optional sorting, optional paging, and if the table contains relevant fields to filter on, you specify you want filtering on these fields too. However, don't create too complex prompts. Keep your prompts SIMPLE!

**IMPORTANT** - If you want filtering suppost on columns, then use prompts such as for instance "equality filtering on column xyz" or "pattern matching filter on column xyz", etc. The point is to describe the type of filter, which can be less than, less than or equal, equal, more than, 'contains' (pattern matching), etc.

**IMPORTANT** - When specifying arguments for CRUD endpoints to the Hyperlambda Generator, make sure you mention whether or not an argument is optional or not!

**Create CRUD verb**

```plaintext
Executable Hyperlambda file creating a single item in [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users and returns the ID of the newly created record.

The endpoint accepts the following arguments.
- [ARG1] of type [TYPE_HERE1]
- [ARG2] of type [TYPE_HERE2]

Return the primary key of the new item as `result`.
```

Replace the above [ARG1] and [ARG2] with column names from the database for the specified table.

**Read CRUD verb**

```plaintext
Executable Hyperlambda file returning items from [DATABASE] database and its [TABLE] table.
The endpoint can be optionally paged and sorted, only be invoked by 'root' users, and returns a list of rows from the database.

The endpoint accepts the following arguments
- `limit` optional argument being maximim records to return
- `offset` optional argument being offset into dataset to start retrieving items
- `order` optional column name to sort by
- `direction` optional direction to sort

Return the following columns
- COLUMN_A
- COLUMN_B
- COLUMN_C
```

**IMPORTANT** - For CRUD read endpoints also specify you want optional filtering on relevant columns. Don't add too many filters to your prompts, and keep your prompts simple. Here's an example filtering condition you can add to your prompts; "Add patternmatching filtering on the 'CompanyName' column."

**Update CRUD verb**

```plaintext
Executable Hyperlambda file updating a single item in [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users and returns how many rows were affected.

The endpoint accepts the following arguments.
- [PRIMARY_KEY_FOR_TABLE] of type [TYPE_HERE1]
- [ARG1] of type [TYPE_HERE1]
- [ARG2] of type [TYPE_HERE1]

Return how many rows was affected as `result`.
```

Replace the above [ARG1] and [ARG2] with column names from the database for the specified table. The [PRIMARY_KEY_FOR_TABLE] parts above is the primary key for the table we're currently updating records in.

**Delete CRUD verb**

```plaintext
Executable Hyperlambda file deleting a single item from [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users.

The endpoint accepts the following arguments.
- [PRIMARY_KEY_FOR_TABLE] of type [TYPE_HERE1]

Return how many rows was affected as `result`.
```

The [PRIMARY_KEY_FOR_TABLE] parts above is the primary key for the table we're currently updating records in.

When you are done with all verbs the user wants then offer the user to use your HTTP function to invoke the HTTP GET endpoint to test the API.
