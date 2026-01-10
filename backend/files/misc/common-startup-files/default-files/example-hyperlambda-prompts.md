Example Hyperlambda prompts

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

Once generated using the "generate-hyperlambda" function, the code can be immediately executed resulting in the result from the execution being transmitted back to the LLM.

**IMPORTANT** - The Hyperlambda Generator depends upon *exact information*. If the user is asking you to create Hyperlambda that interacts with a database for instance, and doesn't give you the exact fields or columns, you can use the "database-schema" function to retrieve the schema for the database such that you can generate the correct prompt referencing the correct database columns, that returns the required fields.
