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

## Patch format rules

The patch parser is intentionally strict. It only accepts a limited unified diff format and will throw if the patch deviates.

* The patch must target **exactly one file**.
* Each hunk must start with a header line in this format: `@@ -a,b +c,d @@`.
* Every line inside a hunk must begin with one of these characters:
  * ` ` (space) for context lines
  * `-` for deletions
  * `+` for additions
  * `\` for the `\ No newline at end of file` marker
* Empty lines inside a hunk are only allowed if they are prefixed by a **space** (`" "`).
* Context lines must match the file content **exactly**, otherwise the patch will fail.
* Line numbers in the hunk header must match the file, otherwise the patch will fail.

### Minimal safe example

The following illustrates the most reliable format for a single-line change.

```
@@ -5,1 +5,1 @@
-Old line here
+New line here
```
