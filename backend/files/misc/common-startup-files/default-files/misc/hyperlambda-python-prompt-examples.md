# INFO; Hyperlambda Python Prompt Examples

You can use the Hyperlambda Generator to create Python execution code in Magic.

Before generating code, decide whether to run:
- a Python file (`file`)
- inline Python code (`code`)

Only one of these can be used at a time. If both are provided, execution fails.

Use prompts such as:

* _"Execute Python code that returns the first 20 Fibonacci numbers as JSON."_
* _"Execute the Python file '/etc/python/report.py' with arguments and return the result."_

You can also post-process output, for example:

* _"Execute Python code that reads a CSV from '/etc/tmp/sales.csv', returns JSON, and then filter the result to include only items with amount > 1000."_

## Python execution behavior

- Python is executed through `python.execute`.
- Arguments can be passed through `args` (list or string).
- Optional `stdin` input is supported.
- Optional `working-directory` is supported.
- Optional `timeout` is supported (default 30 seconds).
- The slot returns stdout and throws on non-zero exit code.

## Good prompt patterns

* _"Create Hyperlambda that executes inline Python (`code`) to parse input JSON from stdin and return transformed JSON."_
* _"Create Hyperlambda that executes '/etc/python/my_script.py' with args `['--mode', 'fast']` and returns stdout."_
* _"Create Hyperlambda that sets timeout to 60 seconds, runs Python code, and returns only the final JSON line."_

## Important constraints

- Do not provide both `file` and `code`.
- Prefer JSON output from Python (`print(json.dumps(...))`) for reliable downstream parsing.
- Keep Python dependencies to stdlib unless environment guarantees additional packages.
