# Function; Delete file
FUNCTION ==> delete-file

Deletes an existing file.


Below is the exact function signature and JSON invocation format for this function.

```plaintext
___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/delete-file.hl]:
{
  "filename": "[STRING_VALUE]"
}
___
```

Arguments:

- `filename` is the mandatory filename, including its path.

Notice, you can only delete files inside the "/etc/" or the "/modules/" folders.

**Warning**! This action is permanent and user needs to acknowledge he or she understands the consequences.
