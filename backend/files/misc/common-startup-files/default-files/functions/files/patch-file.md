# Function; Patch file
FUNCTION ==> patch-file

Applies a unified diff patch to an existing file.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/files/patch-file.hl]:
{
  "filename": "[STRING_VALUE]",
  "patch": "[STRING_VALUE]"
}
___

## Arguments

* `filename` is the mandatory filename and must be a fully qualified path, such as for instance "/modules/foo/bar.hl".
* `patch` is the mandatory unified diff patch to apply.

Notice, you can only patch files in the "/etc/" and "/modules/" folders.
