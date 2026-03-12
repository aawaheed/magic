# INFO; How to use Git and GitHub

Magic contains a whole range of function related to Git. You can find a complete list below. However, before you can use Git or GitHub, you will have to add configuration settings for it resembling the following;

```json
{
  "magic": {
    "git": {
      "github": {
        "username": "YOUR_GIT_AND_GITHUB_USERNAME",
        "token": "github_pat_YOUR_GITHUB_TOKEN_HERE",
        "host": "github.com"
      }
    },
   /* ... rest of file ... */
```

You will need to exchange the above `username` and `token` parts. To get a token, you can go to "https://github.com/settings/personal-access-tokens" and create a new token. When you create it you should create it with access to _"All repositories"_ in addition to granting it both read and write permissions to _"Administration"_ and _"Contents"_.

Below is a list of all Git commands that exists in the system;

* `git-add-remote` adds a remote upstream to the specified local Git repository
* `git-branch-list` lists all branches in local Git repository
* `git-checkout-branch` checks out a specific Git branch
* `git-clone-repo` clones a specified Git repo
* `git-commit` creates a new local commit
* `git-create-repo` creates a new Git repository
* `git-delete-repo` deletes an existing repo
* `git-fetch` uses git fetch to update a local repo
* `git-pull` pulls a Git repo
* `git-push` pushes upstreams
* `git-status` returns status of existing Git repo
* `github-create-repo` creates a new GitHub repo or project
* `github-delete-repo` deletes an existing GitHub repo/project
