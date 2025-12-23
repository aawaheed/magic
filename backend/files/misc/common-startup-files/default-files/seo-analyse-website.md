Workflow; SEO analyse website
WORKFLOW ==> seo-analyse-website

Magic can use the Hyperlambda to generate code that helps users analyse SEO quality of websites. Below are example prompts you can run through the "generate-hyperlambda" function that can help you perform a technical SEO analysis of an entire website hierarchy, or individual pages on sites.

* "Crawl ainiro.io's sitemap for all URLs not containing '/blog/' in their URLs and return the H1 header, the title tag, and the meta description from all pages you crawl"
* "Scrape ainiro.io/white-label and return the HTTP status code and ALT tag value for all images you find on the page"
* "Get the H1, meta description, and title from www.hubspot.com"
* "Fetch all hyperlinks with their trimmed anchor text values from xyz.com/articles/foo, and return these"
* "Scrape xyz.com/data/reports and return the Organization JSON-LD schema"
* "Crawl all hyperlinks from ainiro.io and return their HTTP status codes and trimmed H1 value"
* "Return all 404 URLs from ainiro.io's sitemap"
* "Return all dead links from ainiro.io/white-label"
* "Crawl the first 5 URLs from ainiro.io's sitemap containing '/blog/' and return the Markdown version of the first 'article' element you find, in addition to all URLs referenced inside the markdown"
* "Crawl all URLs from ainiro.io/sitemap.xml and return all H1 values, title values, and meta descriptin values"
* "Crawl all URLs from ainiro.io/ai-agents and insert these into database x, table y, having columns 'url' and 'text'"
* "Fetch all external hyperlink URLs from 'https://ainiro.io/crud-generator' and return their HTTP status codes and response headers."
* "Scrape ainiro.io, fetch all image URLs, and insert these into the 'cms' database and its 'images' table as absolute URLs"
* "Crawl all images on ainiro.io and measure how many milliseconds each image takes to load, and return milliseconds plus Content-Length URL, plus URL and ALT tag for all images found"

The point being that queries such as the above can help you understand the SEO quality of the user's website, and allows you to analyse its structure, headers, etc, and advice the user in regards to how to search engine optimise (SEO) his or his clients websites.

If the user tells you he or she wants to SEO analyse a website, you should follow this workflow and ask the user for the following information.

1. Website URL he wants to analyse.
2. What type of SEO information, and/or questions he wants to have answered.
   - Be creative here, and come with suggestions to the user.
3. If the user asks you to crawl "all URLs from sitemap" or something, then you **MUST** first count URLs in sitemap, and if the number of URLs is very large (larger than 50), you should warn the user, and suggest limiting conditions, and/or filtering conditions.
4. If there's more than 50 URLs, you can prompt the Hyperlambda generator with for instance; "Return the first 30 URLs from the sitemap at ainiro.io" to suggest some filtering conditions to exclude for instance pages containing '/articles/', etc.
5. Suggest some 1 to 5 prompts for the Hyperlambda generator that extracts important information, and show these to the user, and explain why they could help.
6. Generate the Hyperlambda using the "generate-hyperlambda" function, execute the Hyperlambda, and display the result to the user.
7. Use the retrieved data to perform your analysis, and help guide the user in regards to SEO of the specified website, producing a comprehensive report of all findings, emphasising improvements at the end.
8. When done, offer the user to create a downloadable PDF report. You can use the "create-pdf-file-from-html" function and for instance save the PDF report with some filename inside the '/etc/tmp/' folder, and use the "download-file" function to allow the user to download the file.
   - If you need to create a temporary file, then create this inside of "/etc/tmp/", and make sure you provide a backlink in the PDF to "https://ainiro.io".
   - When you have generated a temporary PDF file, use the "download-file" function to allow the user to download the report.

**IMPORTANT** - BEFORE you start crawling every page from a sitemap, or all hyperlinks from pages, etc, please create prompts that counts how many URLs, hyperlinks, or images, etc, you can expect to find. Below are some example prompts.

* "Fetch the sitemap from ainiro.io and return how many URLs it contains"
* "Scrape ainiro.io/ai-agents and count how many images and hyperlinks you can find"
* "Return the first 30 URLs from the sitemap at ainiro.io" - With the intention of trying to see if you can add filtering conditions when returning or crawling URLs from the sitemap.
* Etc ...

If there are too many URLs to deal with in one go, you can construct queries to suggest filtering conditions, such as for instance; 

* "Get the first 50 URLs from the sitemap at ainiro.io"

You can also measure performance by using something such as follow;

* "Scrape ainiro.io/white-label and measure how much time is required to download each image, in addition to their Content-Length header"
* Etc ...

The latter would allow you to measure performance of website loading, at least from the perspective of where the cloudlet is running.

**IMPORTANT** - If the user asks you to crawl all pages from his or her sitemap, then you should first generate a prompt to count how many URLs the sitemap contains, and if this number is larger than 50 URLs, you should warn the user that it might be too much data to deal with at the same time, and offer the user to analyse a sub-section of his or her website instead, such as the first 25 URLs, etc.

The generated Hyperlambda will return JSON to you, and if you crawl 100 pages for all hyperlinks, all images, or all meta descriptions, etc, then the context window might overflow, and it might be too much data to deal with at the same time.

**IMPORTANT** If the user wants a PDF report, it is CRUCIAL that you save this file in "/etc/tmp/" using the "create-pdf-file-from-html" function with a proper relevant filename, and use the "download-file" function afterwards to allow the user to download the report. The "create-pdf-file-from-html" function will return a full path you can pass into the "download-file" that will generate a download button in the UI. It is CRUCIAL that you follow this process for generating PDF reports and allowing the user to download the file. The file CANNOT be served by its path alone, since it requires authentication to download files.
