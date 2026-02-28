# Workflow; Create Terminal Hyperlambda function
WORKFLOW ==> create-terminal-hyperlambda-function

## Purpose

Allow the user to wrap a terminal command inside a Hyperlambda HTTP endpoint, and/or executable Hyperlambda file.

## Steps

1. Ask the user what he or she wants the terminal command to actually do.
2. Show a terminal command that accomplishes the user's request to the user.
3. Ask the user to accept the validated terminal command.
4. Use the Hyperlambda Generator and its `generate-hyperlambda` function to generate Hyperlambda code that executes the command, and optionally returns the result to caller. You can find an example prompt below.
   - Make sure you offer the user to secure the endpoint or Hyperlambda file such that only users belonging to some specific role(s) can execute it.
5. Once the user is satisfied, offer the user to save the generated Hyperlambda into a Hyperlambda file inside a module using the `create-file` function.

```plaintext
HTTP endpoint that executes the following terminal command `ls -l blah, blah, blah` and returns the result to the caller.
```

Optionally add a list of arguments or authorization requirements, etc.

Show the prompt to the user and immediately generate the Hyperlambda and show the resulting Hyperlambda to the user, and ask the user if you should save the Hyperlambda file inside a module. Notice, you'll have to ask the user what module the user wants to save the Hyperlambda file in. Offer the user to create a new module using the `create-module` function.

## Code Generation Rules (Environment Safety)

When generating code:

1. Assume NON-interactive, programmatic execution by default.
   - Do NOT use shell operators like `&&`, `|`, `>`, `*`, or globbing.
   - Do NOT assume a terminal or interactive shell unless explicitly requested.

2. Do NOT assume a specific operating system.
   - If OS-specific behavior is required you can execute the function named `get-operating-system` which will return the operating system to you.
     - Search for the function using `get-context` unless you already have its signature in your context.

3. Prefer native language/runtime APIs over shell commands.
   - Only use external process execution if no native API exists.
   - Never rely on tools that may not exist on all systems.

4. When executing external processes:
   - Specify executable and arguments separately.
   - Do not rely on shell parsing unless explicitly required.
   - Include proper error handling.

5. Before returning code, internally verify:
   - No shell-only syntax is used unintentionally.
   - No hidden OS assumptions exist.
   - The solution would run in a backend/server context.

If any rule is violated, regenerate the solution.
