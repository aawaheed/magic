# INFO; Widget rules

## Core rules

1. Always use absolute URLs with the backend URL in JavaScript when fetching data from the backend.
2. Never use `DOMContentLoaded` in widget JavaScript.
3. Prefix all widget HTML `id` attributes, CSS selectors, JavaScript namespaces, and JavaScript functions with `WIDGET_ID_UNIQUE_NUMBER`.
4. Save widget HTML inside a module, not in `/etc/www/`.
5. Account for HTTP endpoints returning empty string instead of `[]` or an empty object.
6. If the widget requires a backend, offer to create the API using the Hyperlambda Generator.
7. Widgets are rendered into a shadow DOM, so do not use `document.querySelector`, `document.getElementById`, or `document.querySelectorAll`. Use:
   - `ainiro.$`
   - `ainiro.$id`
   - `ainiro.$$`
8. By default, the root HTML element should have `min-width: 80%` unless the user asks for something else.
9. To render a widget inline in the chatbot, search for `display-html-widget`.
10. To attach a widget to an AI chatbot or machine learning type, search for `add-html-widget`.

## Related files

- Search for `create-widget` for the widget creation workflow.
- Search for `background-images` if you need image references for widget design.
