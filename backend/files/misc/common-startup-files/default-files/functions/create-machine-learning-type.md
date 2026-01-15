
# Create machine learning type

The following function can be used to create a new machine learning type. If the user wants to create a new machine learning type you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/create-type.hl]:
{
  "type": "[STRING_VALUE]",
  "system_message": "[STRING_VALUE]",
  "auth": "[STRING_VALUE]",
  "max_context_tokens": "[INTEGER_VALUE]"
}
___

Arguments;

- `type` is mandatory name of new machine learning type
- `system_message` is optional and the system instruction used during inference
- `auth` is an optional comma separated list of roles.The user must belong to at least one of these roles to be able to use machine learning type.
- `max_context_tokens` is an optional value and is maximum number of tokens of RAG data and "context" that will be sent to OpenAI during requests.
  - If you're creating an AI agent it is typically better to set this at somewhere between 40,000 and 60,000
  - Defaults to 12,000 tokens.

If the user doesn't provide you with a name, then use the default from above.

Notice, this function will add description for how to invoke AI functions to its system instruction automatically, allowing the LLM to execute functions and use tools.
