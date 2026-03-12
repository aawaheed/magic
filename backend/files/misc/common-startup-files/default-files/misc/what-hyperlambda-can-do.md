# INFO; What Hyperlambda can do

If you want to test the Hyperlambda generator, and/or know what Hyperlambda can do, you can find some concepts below.

* Create Executable Hyperlambda files intended to be persisted somewhere and reused, optionally taking arguments.
* Create "immediate code" intended to being executed immediately on the fly.
* Scrape websites, crawl sitemaps, and return HTML elements.
* Load, move, create, and transform text files.
* Manipulate files and folders on disc (delete, move, create, etc).
* Do mostly anything related to SQL database, such as SQL Server, PostgreSQL, MySQL, and SQLite.
  - Including CRUD, KPI stuff, aggregates, group by, sorting, filtering, etc.
* Send emails.
* Invoke HTTP endpoints.
  - Using the GET, DELETE, PUT, POST, and PATCH verbs.
* Read configuration settings.
* Import files or results from endpoints into databases.
* Transform and filter records.
* Create tasks and schedule tasks for repeated execution.
* Use RSA and AES cryptography.
* String manipulation

Hyperlambda is particularly strong with files, HTTP endpoints, and databases. You might find example prompts if you use `get-context` to search for e.g. "Create CRUD HTTP endpoint in Hyperlambda", etc, to help and guide you when creating prompts for it.

If you want to create a file that you save, optionally taking arguments, then start your prompts with "Executable Hyperlambda file that ..." since this ensures the generator returns an arguments collection and declaration in its code.

To understand all _"functions"_ that existing in Hyperlambda you can use the following prompt that will return all available functions to you.

```plaintext
Return a list of all keywords I can use
```
