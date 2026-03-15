# Workflow; Create Python Hyperlambda function
WORKFLOW ==> create-python-hyperlambda-function

## Purpose

Allow the user to wrap Python scripts inside an executable Hyperlambda file.

## Steps

1. Ask the user what he or she wants the Python code to actually do.
2. Create Python code and show it to the user.
   - Return only Python 3 code.
   - Require a `main()` function and `if __name__ == "__main__": main()` guard.
   - Require all inputs to be read from `sys.argv` and validated.
   - Require JSON output to stdout only.
3. Ask the user if the Python code has side effects (filesystem writes, network calls, DB updates, emails, etc).
   - If yes, ask the user explicitly if the code should be executed for validation.
4. Validate the Python code using `python.execute` with minimal test arguments.
   - Only execute if the user accepts validation when side effects exist.
   - If execution fails or returns stderr/non-zero exit code, fix the Python code and retry.
5. Ask the user to accept the validated code.
6. Save the Python code inside of "/etc/python/" with a relevant filename using the `create-file` function.
   - If `create-file` is not already in context with exact signature and filename, retrieve it using `get-context` according to the Tool lookup minimization policy, and use this function to save the Python code.
   - Use `create-folder` to ensure the folder already exists. If `create-folder` is not already in context with exact signature and filename, retrieve it using `get-context` according to the Tool lookup minimization policy.
7. Use the Hyperlambda Generator and its `generate-hyperlambda` function to generate Hyperlambda code that executes the Python script, and optionally returns the result to caller. You can find an example prompt below.
   - Make sure you offer the user to secure the endpoint or Hyperlambda file such that only users belonging to some specific role(s) can execute it.
8. Once the user is satisfied, offer the user to save the generated Hyperlambda in a module.

```plaintext
Executable Hyperlambda file that executes the Python file found at `/etc/python/WHATEVER_FILE_NAME_HERE.py` and returns the result to caller.
- First argument does xyz
- Second argument does qwe
```

Optionally add a list of arguments such as illustrated above.

Show the prompt to the user and immediately generate the Hyperlambda and show the resulting Hyperlambda to the user, and ask the user if you should save the Hyperlambda file inside a module. Notice, you'll have to ask the user what module the user wants to save the Hyperlambda file in. Offer the user to create a new module using the `create-module` function.

If the Python code returns JSON through stdout, then make sure you specifically say this in your Hyperlambda prompt, and tells the Hyperlambda Generator something as follows in your prompt; "The Python code returns JSON. Make sure you return this as structured output to the caller."

**IMPORTANT** - Notice, your Python code cannot rely upon importing packages. It must be standard Python code.
