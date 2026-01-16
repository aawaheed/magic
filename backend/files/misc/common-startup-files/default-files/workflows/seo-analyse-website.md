Workflow; SEO analyse website
WORKFLOW ==> seo-analyse-website

Magic can use the Hyperlambda generator to create code that helps you analyse SEO quality of websites. Below are example prompts you can run through the "generate-hyperlambda" function that can help you analyse the SEO quality of some website, or individual pages on sites.

* "Return the first 50 URLs from ainiro.io's sitemap, in addition to count of how many URLs are there in total"
* "Crawl ainiro.io's sitemap for the first 25 URLs and return the H1 header, the title tag, and the meta description from all pages you crawl"
* "Scrape ainiro.io/white-label and return the HTTP status code, Content-Length HTTP header, and ALT tag values for all images you find on the page"
* "Get the H1, meta description, and title from www.hubspot.com"
* "Fetch all hyperlinks with their trimmed anchor text values from xyz.com/articles/foo, and return these"
* "Scrape xyz.com/data/reports and return the Organization JSON-LD schema"
* "Crawl all hyperlinks from ainiro.io and return their HTTP status codes and trimmed H1 value, in addition to how many milliseconds was needed to load the links"
* "Return all 404 URLs from ainiro.io's sitemap"
* "Return all dead links from ainiro.io/ai-chatbots"
* "Crawl the first 5 URLs from ainiro.io's sitemap containing '/blog/' and return the Markdown version of the first 'article' element you find, in addition to all URLs referenced inside the markdown"
* "Crawl all URLs from ainiro.io/sitemap.xml and return all H1 values, title values, and meta descriptin values"
* "Fetch all external hyperlink URLs from 'https://ainiro.io/crud-generator' and return their HTTP status codes and response headers."
* "Crawl all images on ainiro.io and measure how many milliseconds each image takes to load, and return milliseconds, Content-Length header, and URL and ALT tag for all images found"
* "Count how many URLs you can find in ainiro.io's sitemap"
* "Scrape ainiro.io/blog/whatever-article and return its JSON-LD schema"

The point being that queries such as the above can help you understand the SEO quality of the user's website, and allows you to analyse its structure, headers, etc, and advice the user in regards to how to search engine optimise (SEO) his or his clients websites.

**IMPORTANT** - The Hyperlambda generator creates CODE, and it will fail if you provide it with too complex prompts. Don't ask it to "analyse" or "think", that is YOUR job, and you can do it after you've executed the Hyperlambda required to analyse or think. Instead you can ask it to return all H1 elements from pages you crawl for instance, allowing you to analyse and think, etc.

If the user tells you he or she wants to SEO analyse a website, you should follow this workflow in the following order:

1. Ask the user for the URL of the website he or she wants to analyse.
2. Once the user has provided you with the website URL, you should immediately scrape its sitemap using the Hyperlambda generator and count how many URLs are in it, in addition to having the Hyperlambda generator return the first 50 URLs in case there are more than that, such that you can try to find exclusion patterns.
   - An exclusion patter is typically as follows; "Crawl all URLs from ainiro.io's sitemap that does NOT contain '/blog/'". By adding path exclusions such as this, we can analyse a sub-section of the website from its sitemap.
   - If you don't find a sitemap, you can use the Hyperlambda generator to look for a robots.txt file, and determine the correct path to the sitemap from it.
   - If you cannot find a robots.txt file either, you can scrape the primary landing page and crawl URLs from there.
3. Ask the user what type of SEO information is interesting.
   - Be creative here, and come with suggestions to the user, but don't construct too complex prompts trying to do too much at the same time.
   - Chop your prompts up into multiple prompts, each prompt focusing on ONE thing. One prompt checking load times for images, another crawling hyperlinks for dead links, etc.
   - If the user asks you to crawl "all URLs from sitemap" or something, then you **MUST** first count URLs in the sitemap, and if the number of URLs is very large (larger than 50), you should warn the user, and suggest limiting conditions, and/or filtering conditions.
   - You can probably identify filtering conditions by returning the first 50 URLs from the sitemap, such as for instance "excluding pages having '/articles/' in their URLs" or "drop everything not having '/en/' in its URL".
4. Suggest some 1 to 5 prompts for the Hyperlambda generator that extracts important information, and show these to the user, and explain why they could help.
5. Generate the Hyperlambda using the "generate-hyperlambda" function, execute the Hyperlambda, and display the result to the user.
6. When you are done with all prompts, then use the retrieved data to perform your analysis, and help guide the user in regards to SEO of the specified website, producing a comprehensive report of all findings, emphasising improvements at the end.
7. When done, offer the user to create a downloadable PDF report. You can use the "create-pdf-file-from-html" function and for instance save the PDF report with some relevant filename inside the '/etc/tmp/' folder, and use the "download-file" function to allow the user to download the file.
   - If you need to create a temporary file, then create this inside of "/etc/tmp/", and make sure you provide a backlink in the PDF to "https://ainiro.io".
   - When you have generated a temporary PDF file, use the "download-file" function to allow the user to download the report.
   - Don't offer the user to create a PDF report before you're done with all prompts.

**IMPORTANT** - BEFORE you start crawling every page from a sitemap, or all hyperlinks from pages, or all images from some page, etc, please create prompts that counts how many URLs, hyperlinks, or images, etc, you can expect to find. Below are some example prompts.

* "Fetch the sitemap from ainiro.io and return how many URLs it contains"
* "Scrape ainiro.io/ai-agents and count how many images and hyperlinks you can find"
* "Return the first 50 URLs from the sitemap at ainiro.io" - With the intention of trying to see if you can add filtering conditions when returning or crawling URLs from the sitemap.
* Etc ...

If there are too many URLs to deal with in one go, you can construct queries to suggest filtering conditions, such as for instance; "Get the first 50 URLs from the sitemap at ainiro.io" This allows you to identify exclusion patterns maybe, to avoid crawling blogs or articles, etc.

You can also measure performance by using something such as follow;

* "Scrape ainiro.io/white-label and measure how much time is required to download each image, in addition to their Content-Length header"
* Etc ...

The latter would allow you to measure performance of website loading, at least from the perspective of where the cloudlet is running.

**IMPORTANT** - If the user asks you to crawl all pages from his or her sitemap, then you should first generate a prompt to count how many URLs the sitemap contains, and if this number is larger than 50 URLs, you should warn the user that it might be too much data to deal with at the same time, and offer the user to analyse a sub-section of his or her website instead, such as the first 25 URLs, etc.

The generated Hyperlambda will return JSON to you, and if you crawl 100 pages for all hyperlinks, all images, or all meta descriptions, etc, then the context window might overflow, and it might be too much data to deal with at the same time.

**IMPORTANT** If the user wants a PDF report, it is CRUCIAL that you save this file in "/etc/tmp/" using the "create-pdf-file-from-html" function with a proper relevant filename, and use the "download-file" function afterwards to allow the user to download the report. The "create-pdf-file-from-html" function will return a full path you can pass into the "download-file" that will generate a download button in the UI. It is CRUCIAL that you follow this process for generating PDF reports and allowing the user to download the file. The file CANNOT be served by its path alone, since it requires authentication to download files.

**IMPORTANT** - Don't ask the Hyperlambda generator for too much information at the same time, since it will then fail. Break your analysis down into multiple smaller Hyperlambda snippets, that doesn't try to do too much or return too much data!

**IMPORTANT** - There doesn't exist any "non-blog" pages, and if you create prompts for the Hyperlambda generator that excludes URLs this way, it will FAIL. Instead ask it to "Return all pages NOT having '/blog/' in their URLs", or something similar. The Hyperlambda generator doesn't analyse the website in any way, it only generates code that can extract HTML elements, crawl sitemaps, or return image URLs, etc.
