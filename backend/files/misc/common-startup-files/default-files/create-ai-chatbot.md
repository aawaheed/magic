Workflow; Create AI chatbot
WORKFLOW ==> create-ai-chatbot

Use this workflow if the user wants to create an AI chatbot. Before you can begin you need to ask the user the following questions:

1. Ask the user for a name for the AI chatbot. This will become the name of the machine learning type. The name can only contain lowercase characters, numbers, `-` and `_` characters.
   - When creating this model do NOT apply any auth requirements.
2. Offer to crawl and scrape a website to generate training data.
   - You will need to ask the user for the URL to the website he or she wants to crawl.
   - You'll have to ask the user for how many pages he or she wants to import.
   - If the user provides you with a URL then scrape the landing page at the specified URL and use the content returned to create a high quality system instruction you use when creating the machine learning type. This system instruction will be used for a sales AI chatbot.
   - Use the "crawl-website" AI function you've already got in your system instruction to crawl and scrape pages.
3. Suggest to the user that you can create a send email AI function, that sends an email to the client's lead generation email address.
   - Ask the user for what email address and name to send emails to and exchange '[NAME_AS_SPECIFIED_BY_USER]' and '[EMAIL_AS_SPECIFIED_BY_USER]' in the template below.
   - Below is an example instruction you can use as a template for the Generate Hyperlambda function if the user wants a send email AI function
   - Save this file in a module having the same name as the type. Make sure you verify that the modul exists from before, and if not, create it.
4. Inform the user that he needs to vectorize the type before the AI function can be used, and offer the user to vectorize the type.

Once you've got all the above information, then execute these steps in order:

1. Scrape the base URL to create a high quality system instruction for selling services found at the website using the "scrape-url" function.
2. Create the machine learning type with the system instruction created above.
3. Start crawling and scraping for RAG data using the "crawl-website" function.

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

When saving the Hyperlambda file for sending emails then use the following file level comment:

```hyperlambda
/*
 * Send an email
 *
 * Sends an email to '[NAME_AS_SPECIFIED_BY_USER]' to escalate the conversation to a human being.
 * All arguments are mandatory, but unless the user explicitly says something else, use the current conversation
 * to create a summary that you use as [subject] and [body]. The [name] and [email] arguments is the name and email
 * of the user. The email will be sent to '[EMAIL_AS_SPECIFIED_BY_USER]'.
 */
```

**IMPORTANT** - When you are done with the above process, inform the user of that the machine learning type is not vectorized, and that the user needs to vectorize it before the RAG data takes effect. Then suggest to create an embed script for the user. This is a special workflow called "Create Embed Script for AI Chatbot" that helps you generate the script tag to include the AI chatbot on a website.

**IMPORTANT** - If the user tells you he or she wants you to follow the "Create Embed Script for AI Chatbot" workflow, then use the "get-context" function to retrieve this workflow, unless you've already got it in your context!
