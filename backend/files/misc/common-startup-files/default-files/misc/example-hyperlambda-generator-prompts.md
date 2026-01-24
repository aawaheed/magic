Example Hyperlambda Generator prompts

Hyperlambda is a DSL that allows you to solve most tasks related to backend software development, and it's very strong on APIs, database CRUD operations, web scraping, managing files, etc. Below are some examples for prompts that should work 100% perfectly.

* "Create an HTTP endpoint accepting paging and sorting arguments that connects to the 'chinook' database and returns 'Artist' rows"
  - Add filtering arguments if you wish.
  - Create HTTP endpoints that creates, deletes, or updates rows.
  - Add logging, or combine with 3rd party APIs.
  - Return graph objects by saying stuff such as "For each 'Artist' row, include all 'Album' rows using 'ArtistId' as your foreign key.
* "Return the first 5 'users' rows for 'magic' database sorted by 'created' descendingly"
  - Creates code that can be immediately executed returning the requested data.
* "Crawl ainiro.io's sitemap for all URLs that contains '/blog/' in their URLs and return all H1 elements from all pages, in addition to the Markdown of the first 'ARTICLE' element you find."
  - Or return content from individual URLs, save content from URLs into some database, etc, etc
* "Load the file '/README.md', transform it to Markdown, and return its OpenAI API token count, in addition to the Markdown"
* "Crawl all URLs from ainiro.io's sitemap that contains '/blog/' in their URLs, extract trimmed H1 value and Markdown of the first ARTICLE element you find in HTML. Then insert H1 into 'prompt' and Markdown into 'completion' in the 'magic' database and its 'ml_training_snippets' table. Use 'my_chatbot' as a literal for your 'type' value during insertion."
* "Download 'https://ainiro.io' and measure how many milliseconds it took to retrieve the page."
* "Get 'https://ainiro.io/image.jpeg' and return its Content-Type HTTP header"
* "Load '/README.md', encrypt it using AES with password 'xyz', and save the cipher text as 'README_BAK.md'"
* "Create a new RSA keypair for me with bit strength of 4096, and save its public/private keypair as '/etc/public.txt' and '/etc/private.txt'"
* "Loads '/public.txt' which is a public RSA key, and uses it to encrypt the text 'Thomas Hansen was here' and saves the cipher text to '/encrypted.txt'."
* "Calculate the result of (5 + 4) × (3 - 1) and return the result."
* "What weekday is it 5 days from now?"
* "Create a new RSA keypair and save the public key to '/etc/public.txt' and the private key to '/etc/private.txt'"
* "Use the public key at '/etc/john/public_key.txt' to encrypt the file '/README.md' and save the cipher text to '/encrypted.txt'"
* "HTTP endpoint that takes a [channel] argument, and emits a SignalR message to the specified channel, passing in [name] and [email] specified as input arguments to the endpoint."
* "Invoke Stripe API using my bearer token from my 'magic:stripe:secret' configuration setting and return a checkout URL for the price ID 'price_xyz123'."
* "Resize the image found at '/etc/profile.png' to a maximum width of 200px and overwrite the old file."
* "Search DuckDuckGo for 'Thomas Hansen Hyperlambda' and return the first 5 matches."
* "Invoke Chuck Norris API and return a joke"
* "Invoke the Cat Fact Ninja API and return a random cat fact"
* "Create a new user in the 'magic' database and its 'users' table. Insert 'username' as 'foo' and 'password' as 'xyz'. Hash password before saving it."
* "Scrape www.billion-air.org and return the first 5 image URLs found on the landing page. For each image, measure how many milliseconds it takes to load, and return its Content-Length and Content-Type HTTP headers."
* "Get the first user from the 'magic' database and its 'users' table. Return 'username' and 'created' columns only."
* "Load the file '/etc/foo.hl' and replace its existing authorisation requirements, such that only 'root' and 'admin' users can execute the file, for then to save it back to itself again."
* "Log the following to the audit log; 'Backup of magic database was successfully created'"
* "Select top 20 items from the 'log_entries' table in the 'magic' database sorted by 'created' descending, convert the result to CSV and send as an attachment on email to 'thomas@ainiro.io'"
* "Select all records from 'crm' database and its 'contacts' table. For each row, send an email using the [email] and [name] column. Load the file "/etc/email.html" and applies template arguments for the '{{name}}' field on the file before using it as your body. Use "Welcome to Magic" as your subject."
* "Downloads https://ainiro.io and insert all FAQ items from its JSON schema as question/answer pairs into the 'magic' database and its 'ml_training_snippets' table using the question as the 'prompt' column and the answer as the 'completion' column."
* "Loads the CSV file at "/etc/contacts.csv" and insert each row into 'crm' database and its 'contacts' table. `name` from the CSV file goes into the "full_name" column. `email` from the CSV file goes into the "company_email" column."
* "Create a QR code leading to ainiro.io and save to '/etc/tmp/'"

Once generated using the "generate-hyperlambda" function, the code can be immediately executed resulting in the result from the execution being transmitted back to the LLM.

**IMPORTANT** - The Hyperlambda Generator depends upon *exact information*. If the user is asking you to create Hyperlambda that interacts with a database for instance, and doesn't give you the exact fields or columns, you can use the `get-database-schema` function to retrieve the schema for the database such that you can generate the correct prompt referencing the correct database columns, that returns the required fields.

**IMPORTANT** - DO NOT ask the Hyperlambda Generator to create code that "returns JSON" to you. This is its *DEFAULT* behaviour, and it will *ALWAYS* do that. If you give it a prompt that says "return JSON" you will only confuse it!

**IMPORTANT** - If the user is asking you to generate Hyperlambda that somehow interacts with some database, and you've got access to the database and the user is not giving you exact fields, etc - You can use the `get-database-schema` function to retrieve the schema of the database, to help you create better prompts, where you can reference all tables correctly, columns correctly, indexes, foreign keys, etc.

**IMPORTANT** - When creating prompts to scrape website you CANNOT ask for "get me all products from ...". What you CAN do however, is to ask for "Return all hyperlinks inside of DIV elements containing the 'product' CSS class", etc. Remember, the Hyperlambda generator doesn't analyse the HTML, but only generate Hyperlambda code, and it has no idea how to find "the product" or "all services".

## Features

* Anything related to CRUD for MySQL, SQL Server, SQLite, and PostgreSQL.
* Loading and saving files, listing files and folders, and managing files. Mostly text-based files are supported, but rudimentary support for binary files also exists.
* Create HTTP endpoint or executable Hyperlambda files taking arguments.
* Anything related to web scraping.
* Basic cryptography using AES and RSA.
* Reading configuration settings.
* Perform basical calculations.
