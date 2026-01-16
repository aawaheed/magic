Workflow; Create a Signup Landing Page
WORKFLOW ==> create-signup-landing-page

Use this workflow if the user wants to create a landing page for signing up to things, such as for instance signing up for a conference, an email newsletter, a course, etc. Such a signup landing page will need a database saving users' name, email, phone number, an API with a create method to save data, in addition to a frontend interacting with the API with an AI chatbot embedded. Before you can begin you need to determine the following:

1. Ask the user if he or she wants to embed an AI chatbot on the landing page.
   - If the user answer yes, then search for the "Create AI chatbot" workflow using the "get-contex" function, unless you already have this workflow in your context.
   - Once the embed script has been created following the above workflow, you can continue with step 2 below.
2. Suggest a database design to the user, and when the user is satisfied create this database and apply the DDL.
   - Ask the user what type of data he or she wants to save, and change the database design accordingly.
   - Show the design as a simplified Mermaid chart. Make it a SIMPLE Mermaid chart for MermaidJS, and obey all rules related to Mermaid charts from your system instruction.
3. Ask the user what type of design he wants for his landing page, and offer to create a futuristic design, modern design, classic design, etc.

When done, return the URL for the landing page to the user as a Markdown hyperlink.

**IMPORTANT** - You **MUST** search for the "Create AI chatbot" workflow using the "get-context" function to determine. Follow this workflow before continuing to step 2.

**IMPORTANT** - It is crucial that you follow the "Create AI chatbot" workflow's steps, and asks if the user wants to crawl and scrape a website, etc.

**IMPORTANT** - When creating the API make sure it **DOES NOT** require any authentication!
