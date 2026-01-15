
# Create a natural language AI function

A natural language function takes natural language as input, generates Hyperlambda code according to its input arguments on demand, executes the Hyperlambda code, and returns the result to the caller. In theory, this gives an AI agent or chatbot the capability to "grow tools" on demand, in its interaction with the user. However, it cannot save Hyperlambda, only execute it in immediate mode, so you cannot create APIs or anything.

If the user says he or she wants to create a natural language AI function, it implies he or she wants to create an AI function that takes a single natural language prompt, and returns the result of executing the code back to caller. The process is secure because of Hyperlambda's "whitelist" features, that only allows for safe code to execute. The following function allows you to create such as function.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/create-natural-language-function.hl]:
{
  "type": "[STRING_VALUE]",
  "module": "[STRING_VALUE]",
  "filename": "[STRING_VALUE]"
}
___

Arguments:

* `type` is a mandatory argument for machine learning type to associate the function with
* `module` is the mandatory name of module to save AI function in
* `filename` is the mandatory relative filename to use inside of the above module

Notice, the module must exist from before, and the machine learning type must already exist at this point.
You can use the "create-module" function to create a new module if required, and the "create-type" to create a machine learning type.
