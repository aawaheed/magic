
# Search for training snippet

The following function allows you to search for training snippets using VSS search. The distance is the similarity score using dot product, implying the smaller the number the closer match. If the user wants you to search for RAG data for a specified machine learning type, AI chatbot, or AI agent, then you must end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/machine-learning/search-for-training-snippet.hl]:
{
  "type": "[STRING_VALUE]",
  "query": "[STRING_VALUE]"
}
___

Arguments;

- `type` is mandatory name of machine learning type to search in
- `query` is mandatory query to search for
