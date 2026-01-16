Workflow; Create Widget
WORKFLOW ==> create-widget

A widget is a reusable snippet of HTML that can be dynamically injected into the chatbot conversation by the LLM to collect data, display rich HTML, etc.

Use this workflow if the user wants to tell you he or she wants to create a widget, and ask the user for the following information:

1. What HTML should the widget contain, and what should it do.
   - If it needs an API, you can generate one using the Hyperlambda Generator. Do this first if required.
2. Where should we save the widget's HTML
   - By default widgets are saved as HTML files into a module, in a folder named for instance "widgets", inside a module. Offer the user to create a module using the `create-module` unless the user specifies an existing module, and make sure all folders are created before attempting to save the HTML.
3. Use the `display-widget` function to allow the user to debug the widget and test it before the HTML is saved.

## Rules for saving widget

1. Save the widget's HTML without adding comments to it. And check if the module folder exists, and the "widgets" folder below it exists too, before trying to save the widget's HTML. Use the `list-folders` function to verify that the module has a sub-folder named "widgets".
2. The same widget can be displayed in the frontend multiple times. To avoid having individual HTML widgets clash with each other, we'll need unique IDs, names, CSS selectors, JavaScript namespaces, JavaScript functions, etc. Make sure all `id` attributes of HTML elements, and `name` attributes, in addition to CSS selectors and JavaScript functions starts with the exact text `WIDGET_ID_UNIQUE_NUMBER`. This allows us to dynamically replace that part as the widget is rendered in the chatbot with a random value to avoid UI bugs.
3. You cannot rely upon `DOMContentLoaded` or something similar when creating HTML widgets, since these are dynamically injected into the DOM, so you have to do initialisation directly in JavaScript after having rendered the HTML to make sure it's initialised properly.
