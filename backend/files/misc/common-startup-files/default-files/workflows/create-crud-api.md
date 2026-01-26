Workflow; Create CRUD API
WORKFLOW ==> create-crud-api

**IMPORTANT** - Magic Cloud contains contains a CRUD generator that the user can find ![/generator](here). You **MUST** inform the user of the CRUD generator and return the link as Markdown to give the user the option of using the CRUD generator instead to create an API. If you return the URL, then **ALWAYS** return it as a relative URL, since it is a frontend dashboard component, and not running on the same base URL as the cloudlet itself. The URL to the CRUD generator is exactly `/generator`. Return is EXACTLY AS IS, AND DO NOT CHANGE IT!

After you have informed the user of the above, and the user still wants to proceed manually creating his or her CRUD API with AI, you must guide the user through the following steps.

1. Ask the user for what database and table he or she wants to use, and once you know use the `get-database-schema` function to retrieve the schema such that you can create a simple Mermaid chart and suggest columns to the user.
2. Ask for a module name, or if the user wants to use the same name for his module as the name of the database.
3. Ask the user for what CRUD verb he or she wants to generate an API for.
   - Allow the user to override the choices below, but use the prompts below as your template.
4. Ask the user for what authorization requirements his endpoint(s) needs. If the user is building a publicly available AI chatbot or full stack app, you should use "no authorization" as a part of your prompt.
5. Check if the module already exists, and if not, create the module. If the modul already exists, then pause and ask the user if he or she really wants to use the existing module.
6. Run through all of the CRUD prompts below that the user selected and use these as template prompts, one at the time, and generate CRUD HTTP endpoints using the Hyperlambda Generator, and save each file before continuing to the next CRUD verb.
   - By default you should use the table name as the filename. For a contacts table the endpoint filename would be; "contacts.get.hl" for the read verb when saving the generated code, but allow the user to change this, and exchange 'get' with 'post', 'put', and 'delete' according to what verb you're processing.
   - Show the user all prompts to the Hyperlambda Generator before you generate any code.
7. When creating prompts for CRUD read endpoints using the Hyperlambda Generator, then you must specify that you want optional sorting, optional paging, and if the table contains relevant fields to filter on, you specify you want filtering on these fields too. However, don't create too complex prompts. Keep your prompts SIMPLE!

**Create CRUD verb**

```plaintext
HTTP endpoint creating a single item in [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users and returns the ID of the newly created record.

The endpoint accepts the following arguments.
- [ARG1]
- [ARG2]
```

Replace the above [ARG1] and [ARG2] with column names from the database for the specified table.

**Read CRUD verb**

```plaintext
HTTP endpoint returning items from [DATABASE] database and its [TABLE] table.
The endpoint can be optionally paged and sorted, only be invoked by 'root' users, and returns a list of rows from the database.

The endpoint accepts the following arguments
- `limit` optional argument being maximim records to return
- `offset` optional argument being offset into dataset to start retrieving items
- `order` optional column name to sort by
- `direction` optional direction to sort
```

**IMPORTANT** - For CRUD read endpoints also specify you want optional filtering on relevant columns. Don't add too many filters to your prompts, and keep your prompts simple.

**Update CRUD verb**

```plaintext
HTTP endpoint updating a single item in [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users and returns how many rows were affected.

The endpoint accepts the following arguments.
- [PRIMARY_KEY_FOR_TABLE]
- [ARG1]
- [ARG2]
```

Replace the above [ARG1] and [ARG2] with column names from the database for the specified table. The [PRIMARY_KEY_FOR_TABLE] parts above is the primary key for the table we're currently updating records in.

**Delete CRUD verb**

```plaintext
HTTP endpoint deleting a single item from [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users.

The endpoint accepts the following arguments.
- [PRIMARY_KEY_FOR_TABLE]
```

The [PRIMARY_KEY_FOR_TABLE] parts above is the primary key for the table we're currently updating records in.

When you are done with all verbs the user wants then offer the user to use your HTTP function to invoke the HTTP GET endpoint to test the API.
