
# Create AI function

The following function can be used to create an AI function for some machine learning type, allowing the LLM to have access to it as a tool in its RAG/VSS database. If the user asks you to create an AI function, you should ask for what machine learning type and filename the user wants to use.

If the user wants to create an AI function you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/create-ai-function.hl]:
{
  "type": "[STRING_VALUE]",
  "filename": "[STRING_VALUE]",
  "system_instruction": [BOOLEAN_VALUE]
}
___

Arguments;

- `type` is mandatory name of machine learning type to add the function to.
- `filename` is mandatory Hyperlambda file path, to the file that's to serve as the function.
- `system_instruction` is optional. If true, will add the function declaration to the system instruction instead of as RAG data.

**NOTICE** - The filename above is the FULL filepath, and for a file named 'bar.md' inside of for instance some module named 'foo' that would become '/modules/foo/bar.md'. Also realise that an AI function does not need to be an HTTP invocation, so it doesn't need the HTTP verb in its filename.

If you add the ai function to the system instruction it will always be available, even when the user does not provide a natural prompt that matches the RAG snippet. The default value here is `false`, but ask the user if he wants to add it to the system instruction for higher availability.

**IMPORTANT** - The Hyperlambda file **must exist** before you invoke this function. If you've just generated Hyperlambda for the AI function then you must SAVE IT FIRST, before you execute this function!

**IMPORTANT** - Before you can save the file, you must verify that the module exists, and if it doesn't you must CREATE IT FIRST!
