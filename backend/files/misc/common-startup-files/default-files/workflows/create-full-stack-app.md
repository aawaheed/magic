# Workflow; Create Full Stack App
WORKFLOW ==> create-full-stack-app

## Purpose
Provide a guided process for building a full stack app.

## Steps

1. Ask the user which data source to use (database or API).
   - You have to create an API to connect to the backend.
2. Ask user what type of design he or she wants. List some popular ones here and let the user choose.
2. Retrieve the schema or data structure to understand available metrics.
3. Combine HTML, CSS and JS into a responsive full stack app layout, using individual files for JS and CSS.
4. Save the frontend files inside the /etc/www/UNIQUE_EXPOAINABLE_NAME folder as a SPA webpage. Choose a relevant folder name for the app.

## Rules for Hyperlambda Generator

If you need to use the Hyperlambda Generator to create CRUD endpoints, or endpoints in general, you must follow these rules.

1. Do not create one single endpoint that returns all data. Instead create several smaller and simpler HTTP endpoints, that returns one or two concepts max each.

Below are some example prompts for CRUD endpoint. Use your `get-context` function to retrieve example Hyperlambda prompts if the user wants some different type of API endpoints.

**Create CRUD verb**

```plaintext
Executable Hyperlambda file creating a single item in [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users and returns the ID of the newly created record.

The endpoint accepts the following arguments.
- [ARG1]
- [ARG2]
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
```

**IMPORTANT** - For CRUD read endpoints also specify you want optional filtering on relevant columns. Don't add too many filters to your prompts, and keep your prompts simple.

**Update CRUD verb**

```plaintext
Executable Hyperlambda file updating a single item in [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users and returns how many rows were affected.

The endpoint accepts the following arguments.
- [PRIMARY_KEY_FOR_TABLE]
- [ARG1]
- [ARG2]
```

Replace the above [ARG1] and [ARG2] with column names from the database for the specified table. The [PRIMARY_KEY_FOR_TABLE] parts above is the primary key for the table we're currently updating records in.

**Delete CRUD verb**

```plaintext
Executable Hyperlambda file deleting a single item from [DATABASE] database and its [TABLE] table.
The endpoint can only be invoked by 'root' users.

The endpoint accepts the following arguments.
- [PRIMARY_KEY_FOR_TABLE]
```

The [PRIMARY_KEY_FOR_TABLE] parts above is the primary key for the table we're currently updating records in.

When you are done with all verbs the user wants then offer the user to use your HTTP function to invoke the HTTP GET endpoint to test the API.

## Important implementation details

1. If the user wants a GUI, and only authorized users accessing the frontend, you must make sure the primary GUI is **invisible** before users have logged in, and create a log in button or login form or something, and display a log out button after having logged in.

Store token in localStorage. The frontend flow for authentication is as follows;

1. Hide main app and show login UI
2. User logs in
3. Hide login UI and show app UI
4. User logs out (delete token from localStorage)
5. Hide app UI and show login UI

For authentication you can search for and suggest either;

1. Magic Auth (uses primary platform endpoints allowing existing users to log in)
2. Google SSO/OIDC allowing any Google account to login

**IMPORTANT** - If the user wants to use OIDC, it's very important that your Hyperlambda Generator prompts explicitly says something like; "Only 'guest' users can access the endpoint". The point being that only "guest" users are authorized to access the endpoints, unless user explicitly overrides your decision here.
