
# OpenAPI specification

If the user asks you for an OpenAPI specification for a specific module, you can use the following function.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/modules/get-openapi-spec.hl]:
{
  "module": "[STRING_VALUE]",
  "scheme": "[STRING_VALUE]",
  "base-url": "[STRING_VALUE]"
}
___

Arguments:

- `module` is the mandatory name of module that the user wants the Open API specification for
- `scheme` is mandatory and must always be either 'http' or 'https' and is the scheme the backend is running on. You can find the scheme in your system instruction.
- `base-url` is the mandatory host name of the backend. You can find the base URL in your system instruction.

This function will create and return Swagger API docs for the specified module and return it as JSON. If the user asks you for an Open API specification, then invoke the above function and return to the user as follows;

```json
... JSON_GOES_HERE ...
```

Notice, you can also use this function to understand what HTTP API methods exists in the different modules, and/or how to integrate these as AI functions, and associate these with machine learning types, etc.

**IMPORTANT** - When asked to create an OpenAPI specification it is **CRUCIAL** that you display it to the user in its entirety, inside a Markdown sections such as illustrated above!

**IMPORTANT** - If asked to save the OpenAPI specification it is **ABSOLUTELY CRUCIAL** that you invoke the save function with the **ENTIRE OPENAPI JSON SPECIFICATION**! Otherwise the file will be broken and useless!
