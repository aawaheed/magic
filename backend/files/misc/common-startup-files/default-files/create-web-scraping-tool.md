Workflow; Create web scraping tool
WORKFLOW ==> create-web-scraping-tool

**IMPORTANT** - If the user tells you he or she wants to scrape a website, sitemap, or something similar, you should offer the user to follow this workflow, and inform the user of what you can do for him using the Hyperlambda generator.

You can use the Hyperlambda generator to create code on the fly for web scraping operations. You can generate the Hyperlambda using the "generate-hyperlambda" function, and execute it immediately using the "execute-hyperlambda" function, without saving it first. Below are examples of prompts that would work with the Hyperlambda generator and result in working code you can execute and use the results from.

* "Crawl ainiro.io's sitemap for its first three URLs not containing '/blog/' in their URLs and return H1 headers from all page"
* "Scrape ainiro.io/white-label and return the first 20 images you find. Return both alt values and URLs. Make sure you return absolute URLs"
* "Get the H1, meta description, and title from www.hubspot.com"
* "Fetch all hyperlinks with their trimmed text values from xyz.com, and return both URLs and a list of CSS classes associated with each hyperlink"
* "Scrape xyz.com/data/reports and return the trimmed text of all LI items having the 'product' CSS class"
* "Crawl all hyperlinks you find at howdy.com/whatever and return their HTTP status codes, in addition to their Content-Type"
* "Return all 404 URLs from ainiro.io's sitemap"
* "Return all dead links from ainiro.io"
* "Crawl the first 5 URLs from ainiro.io's sitemap containing '/blog/' and return the Markdown version of the first 'article' element you find, in addition to all URLs referenced inside the markdown"

The above are just examples, but if you describe what you want to retrieve from any HTML page, or sitemap, or something similar, the Hyperlambda generator can typically be used to solve the problem, including crawling hyperlinks it finds on web pages, converting HTML to Markdown.

Hence, if the user is asking you to scrape some website or something related to web scraping, you should offer the user to use the Hyperlambda generator and the "generate-hyperlambda" function to create throw away Hyperlambda code that you execute immediately using the "execute-hyperlambda" function.

**IMPORTANT** - DO NOT save such tools unless the user explicitly tells you to do that! And you DO NOT need to instruct the Hyperlambda generator to create code that returns JSON since this is what it does by default.

If the user wants to create a reusable tool, you can invoke the Hyperlambda generator once more with a similar prompt, but this time starting out with "Generate an Executable Hyperlambda file that ...", mentioning input arguments in your prompt, which will give you a function taking arguments that you can persist as a Hyperlambda file in some module. Once it is saved, it can also be added to a machine learning type as an AI function using the "create-ai-function" function. But do NOT do this unless the user asks, but offer to do this after having verified the function successfully works as expected.

If the user asks you to create web scraping tools, then follow this process, unless user explicitly tells you something else.

1. Suggest to use the Hyperlambda generator to create said web scraping tools, and display the prompt(s) you intend to use to the user
2. Generate the required Hyperlambda using the "generate-hyperlambda" function
3. Execute the Hyperlambda in the same message, assuming the user is OK with the code you showed to him or her
4. DO NOT execute the code before you've shown it to the user, unless the user explicitly tells you to do so
