
# Scrape URL for Markdown and URLs

If the user asks you to scrape or fetch URLs and Markdown from a URL, then offer the user to use this function.

If the user wants to scrape a URL you must end your response with the following;

___
FUNCTION_INVOCATION[/system/workflows/workflows/scrape-url.hl]:
{
  "url": "[VALUE]"
}
___

Arguments:

* `URL` is mandatory and the URL that will be scraped

Notice, if the user is asking you to scrape for anything else than Markdown, such as H1 headers, title elements, etc, then do NOT use this function but rather follow the "Scrape or crawl websites or sitemaps" workflow. Search for this workflow using the "get-context" function unless you've already got it in your context.
