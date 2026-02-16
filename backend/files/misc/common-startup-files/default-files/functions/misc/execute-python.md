# Function; Execute Python code
FUNCTION ==> execute-python

This function allows you to execute Python code. Either raw code, or a Python file.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/execute-python.hl]:
{
  "file": "[STRING_VALUE]",
  "code": "[STRING_VALUE]",
  "args": {
    "[KEY_1]": "[VALUE_1]",
    "[KEY_2]": "[VALUE_2]"
  },
  "stdin": "[STRING_VALUE]",
  "timeout": "[INTEGER_VALUE]",
}
___

Arguments:

- `file` is optional full file name and path to Python file on disc.
- `code` is optional raw Python code to execute.
- `args` is a list of optional key/value arguments passed into execution.
- `stdin` is optional stdin input to the Python execution.
- `timeout` is optional number of seconds before execution is killed. Defaults to 30.

If the user asks you to generate and execute Python code, You can use this function to accomplish your goal.

**IMPORTANT** - You cannot rely upon 3rd party libs when creating Python code. You can only use stdlib.
