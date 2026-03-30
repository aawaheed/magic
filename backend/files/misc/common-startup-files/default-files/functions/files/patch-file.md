# Function; Patch file
FUNCTION ==> patch-file

Applies a unified diff patch to an existing file.

Use this function only for small, targeted edits to an existing file after you have read the exact current file content. Use `create-file` when creating a new file, when replacing an entire file, or when you are not certain you can produce an exact patch.

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

The patch parser accepts a strict single-file subset of unified diff format. It is intentionally deterministic and less tolerant than Git-style patch application. If you guess line numbers, counts, context, or newline state, the patch will fail.

* The patch must target **exactly one file**.
* The patch should be generated only after reading the current file content exactly as it exists now.
* Optional file headers are supported using `---` and `+++`. If present, they must refer to the same target file.
* Each hunk must start with a header line in the format `@@ -a,b +c,d @@`.
* Hunk headers may also omit counts for single-line changes, for example `@@ -5 +5 @@`.
* Every line inside a hunk must begin with one of these characters:
  * ` ` (space) for context lines. The leading space is mandatory.
  * `-` for deletions
  * `+` for additions
  * `\` only for the exact line `\ No newline at end of file`
* Empty lines inside a hunk must still be represented as diff lines with a prefix character such as ` `, `-`, or `+`.
* Context lines must match the file content **exactly**, otherwise the patch will fail.
* Hunk line counts are enforced and must exactly match the number of removed, added, and context lines in the hunk.
* Hunks must appear in order and must not overlap.
* If the file ends without a trailing newline and the patch changes the final line, you should include the exact marker `\ No newline at end of file` where needed.

## Required workflow for LLMs

When using this function, follow this workflow exactly:

1. Read the file first.
2. Copy the original lines for the hunk context exactly, including whitespace.
3. Compute the hunk line numbers and counts exactly.
4. Emit a single-file unified diff patch.
5. If you are not fully certain the patch metadata is exact, do **not** use `patch-file`. Use `create-file` instead.

## When not to use patch-file

Do **not** use `patch-file` in these situations:

* You have not read the current file contents first.
* You are changing large parts of the file.
* You are reformatting, reorganizing, or rewriting a CSS, HTML, JavaScript, or Markdown file substantially.
* You are not sure about line numbers, hunk counts, or newline state.
* You cannot preserve exact surrounding context lines.

In these cases, use `create-file` and write the full intended content instead.

### Minimal safe example

The following illustrates the most reliable format for a single-line change.

```
@@ -5,1 +5,1 @@
-Old line here
+New line here
```

### Example with file headers

```diff
--- a/etc/www/site.css
+++ b/etc/www/site.css
@@ -12 +12 @@
-max-width: 420px;
+max-width: 520px;
```
