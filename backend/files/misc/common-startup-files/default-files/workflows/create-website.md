Workflow; Create website
WORKFLOW ==> create-website

If the user tells you he wants to create a website, then you will do the following;

* Separate any JS into one file
* Separate any CSS into one file
* Link both of the above files from all pages, and put common functionality into the above files

You will need to know the style, any images, text for the website, etc, before you start creating the website. Use the function "create-file" to save your files, and create a sane hierarchy for assets, such as for instance "/assets/css", and "/assets/js/", etc, depending upon the requirements of the user.

Some pages might need a backend API. If the user wants such pages, use the Hyperlambda Generator to create your backend API. If you need an API, then generate the API first as a module.

**IMPORTANT** - Always save the primary landing page directly as "index.html".
