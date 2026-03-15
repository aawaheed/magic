Workflow; Create a Signup Landing Page
WORKFLOW ==> create-signup-landing-page

Use this workflow if the user wants to create a landing page for signing up to things, such as for instance signing up for a conference, an email newsletter, a course, etc. Such a signup landing page will need a database saving users' name, email, phone number, an API with a create method to save data, in addition to a frontend interacting with the API with an AI chatbot embedded. Before you can begin you need to determine the following:

1. Ask the user if he or she wants to embed an AI chatbot on the landing page.
   - If the user answers yes, then follow the "Create AI chatbot" workflow. If this workflow is not already in context with exact signature and filename, retrieve it using `get-context` according to the Tool lookup minimization policy.
   - Once the embed script has been created following the above workflow, you can continue with step 2 below.
2. Suggest a database design to the user, and when the user is satisfied create this database and apply the schema / DDL.
   - Ask the user what type of data he or she wants to save, and change the database design accordingly.
   - Show the design as a simplified Mermaid chart. Make it a SIMPLE Mermaid chart for MermaidJS, and obey all rules related to Mermaid charts from your system instruction.
   - When the user confirms the design, use the the `create-sqlite-database` function to create the database, and the `execute-sql` to apply the schema.
3. Ask the user what type of design he wants for his landing page, and offer to create a futuristic design, modern design, classic design, etc. Make "modern design with a background image and glass morphism" the default here.

When done, return the URL for the landing page to the user as a Markdown hyperlink.

**IMPORTANT** - Follow the "Create AI chatbot" workflow before continuing to step 2. Retrieve it with `get-context` only if it is not already in context with exact signature and filename.

**IMPORTANT** - It is crucial that you follow the "Create AI chatbot" workflow's steps, and asks if the user wants to crawl and scrape a website, etc.

**IMPORTANT** - When creating the API make sure it **DOES NOT** require any authentication!

Notice, if you need background image references and they are not already in context, use `get-context` (Tool lookup minimization policy) to search for "background images". Unless the user specifies a different image, then by default use the "blue-flower-pattern-medium-dark-background.jpg" image as a background image to fill the entire viewport.

Notice, when you're assembling the landing page you need to do it in the following order.

1. Create database and apply schema, if user needs a database.
2. Create the API.
3. Create the frontend.

**IMPORTANT** - Apply some default "reset CSS" logic on all CSS you create, such as setting the default `box-sizing` attribute to "border-box", etc.
