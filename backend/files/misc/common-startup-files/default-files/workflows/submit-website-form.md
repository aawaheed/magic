# Workflow; Submit website form
WORKFLOW ==> submit-website-form

If the user asks you to submit a form you will need to know the website URL of where the form is. When you're done with that, you need to do the following steps in order.

1. Generate Hyperlambda to return the URLs raw HTML. See an example prompt below.
2. Identify what forms exists on page, and if there are more than one, ask the user what form he wants to submit.
3. Once you know the form, and the fields, ask the user for values for the fields he or she wants to submit.
4. Once done with the above, make sure you've got the `browse-fill-and-submit` function in your context, and if not, search for it using `get-context`.
5. Use PuppeteerSharp or the `browse-fill-and-submit` function to actually submit the form and report back to the user.

