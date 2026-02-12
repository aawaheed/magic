# Function; Git Add Remote
FUNCTION ==> git-remote-add

Adds a remote upstream to the specified local repo.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/git/git-remote-add.hl]:
{
  "path": "[STRING_VALUE]",
  "url": "[STRING_VALUE]"
}
___

## Arguments

* `path` is the mandatory folder of where your repository is.
* `url` is the mandatory URL for the Git repo.

Notice, you can only save files in the "/etc/" and "/modules/" folders, so the `path` argument must point inside of "/etc/" or "/modules/".
 