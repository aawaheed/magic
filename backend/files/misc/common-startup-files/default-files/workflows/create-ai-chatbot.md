Workflow; Create AI chatbot
WORKFLOW ==> create-ai-chatbot

Use this workflow if the user wants to create an AI chatbot. Before you can begin you need to ask the user the following questions:

1. Ask the user for a name for the AI chatbot. This will become the name of the machine learning type. The name can only contain lower case characters, numbers, "-" and "_" characters.
   - When creating this model do NOT apply any auth requirements.
2. Offer to crawl a website to generate training data.
   - You will need to ask the user for the URL to the website he or she wants to crawl.
   - You'll have to ask the user for how many pages he or she wants to import.
   - If the user provides you with a URL then scrape the landing page at the specified URL and use the content returned to create a high quality system instruction you use when creating the machine learning type. This system instruction will be used for a sales AI chatbot.
   - Use the `crawl-website` function to crawl and scrape pages.
3. Suggest to the user that you can create a send email AI function, that sends an email to the client's lead generation email address.
   - Ask the user for what email address and name to send emails to and exchange '[NAME_AS_SPECIFIED_BY_USER]' and '[EMAIL_AS_SPECIFIED_BY_USER]' in the template below, and offer the user to use his or her name and email address as your default.
   - Below is an example instruction you can use as a template for the Generate Hyperlambda function if the user wants a send email AI function
   - Save this file in a module having the same name as the type. Make sure you verify that the module exists from before, and if not, create it.
4. Inform the user that he needs to vectorize the type before the AI function can be used, and offer the user to vectorize the type.

Once you've got all the above information, then execute these steps in order:

1. Scrape the base URL to create a high quality system instruction for selling services and providing customer service found at the website using the `scrape-url` function.
   - If you don't have the function declaration for this function then you must search for it using the `get-context`.
2. Create the machine learning type with the system instruction created above using the `create-type` function.
   - If you don't have the function required to do this, you can search for it using the `get-context` function to search for it.
3. Start crawling and scraping for RAG data using the `crawl-website` function.
   - Search for this function if you do not have it in your context!

## About send email functions

If the user wants a send email function you must follow these steps;

1. Generate the required Hyperlambda
2. Check if module exists, and if it doesn't you must create it first using the `create-module` function (search for it unless you already have it in your context)
3. Save the file containing the Hyperlambda code using the `create-file` function. If you don't have this function in your context then search for it first.
4. Only when all of the above has been done you can execute the `create-ai-function` function!

## Example prompt for the Hyperlambda Generator

If the user wants to have a send email AI function, you can use the Hyperlambda Generator with a prompt resembling the following to generate such an AI function.

```markdown
Executable Hyperlambda file that sends an email. It takes the following arguments.
- name
- email
- subject
- body

The function will send an email to '[NAME_AS_SPECIFIED_BY_USER]' / '[EMAIL_AS_SPECIFIED_BY_USER]' using the [name] and [email] arguments, and add the [name] and [email] arguments as [reply-to].
```

**IMPORTANT** - When you are done with the above process, inform the user of that the machine learning type is not vectorized, and that the user needs to vectorize it before the RAG data takes effect. Then suggest to create an embed script for the user. This is a special workflow called "Create Embed Script for AI Chatbot" that helps you generate the script tag to include the AI chatbot on a website.

**IMPORTANT** - If the user tells you he or she wants you to follow the "Create Embed Script for AI Chatbot" workflow, then use the `get-context` function to retrieve this workflow, unless you've already got it in your context!

**IMPORTANT** - If you don't have the `crawl-website` function in your context, then you must use the `get-context` function to retrieve it.

**IMPORTANT** - If the user wants a send email function, you have to generate the function first using the Hyperlambda Generator, then make sure the module exists, for then to save the Hyperlambda file inside the module. Only when this is done you can use the `create-ai-function` function to associate the Hyperlambda file as an AI function with the machine learning type. If you do not have this function in your context you can search for it using the `get-context` function.
