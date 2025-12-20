Workflow; SEO analyse website
WORKFLOW ==> seo-analyse-website

Magic can use the Hyperlambda to generate code that helps users analyse SEO quality of websites. Below are example prompts you can run through the "generate-hyperlambda" function that can help you to perform a technical SEO analysis of an entire website hierarchy, or individual pages on sites.

* "Crawl ainiro.io's sitemap for all URLs not containing '/blog/' in their URLs and return the H1 header, the title tag, and the meta description from all pages you crawl"
* "Scrape ainiro.io/white-label and return the HTTP status code for all images you find on the page"
* "Get the H1, meta description, and title from www.hubspot.com"
* "Fetch all hyperlinks with their trimmed anchor text values from xyz.com/articles/foo, and return"
* "Scrape xyz.com/data/reports and return the Organization JSON-LD schema"
* "Crawl all hyperlinks from ainiro.io and return their HTTP status codes and trimmed H1 value"
* "Return all 404 URLs from ainiro.io's sitemap"
* "Return all dead links from ainiro.io/white-label"
* "Crawl the first 5 URLs from ainiro.io's sitemap containing '/blog/' and return the Markdown version of the first 'article' element you find, in addition to all URLs referenced inside the markdown"
* "Crawl all URLs from ainiro.io/sitemap.xml and return all H1 values, title values, and meta descriptin values"
* "Crawl all URLs from ainiro.io/ai-agents and insert these into database x, table y, having columns 'url' and 'text'"
* "Fetch all external hyperlink URLs from 'https://ainiro.io/crud-generator' and return their HTTP status codes and response headers."
* "Scrape ainiro.io, fetch all image URLs, and insert these into the 'cms' database and its 'images' table as absolute URLs"

The point being that queries such as the above can help the user to understand the website, and allows you to analyse its structure, headers, etc, and advice the user in regards to how to search engine optimise (SEO) his or his clients websites.

If the user tells you he or she wants to SEO analyse a website, you should follow this workflow and ask the user for the following information.

1. Website URL he wants to analyse.
2. What type of SEO information, and/or questions he wants to have answered.
   - Be creative here, and come with suggestions to the user.
3. Suggest some 1 to 5 prompts for the Hyperlambda generator that extracts important information, and show these to the user, and explain why they could help.
4. Generate the Hyperlambda using the "generate-hyperlambda" function, execute the Hyperlambda, and display the result to the user.
5. Use the retrieved data to perform your analysis, and help guide the user in regards to SEO of the specified website.
6. When done, offer the user to create and return a report to the user
