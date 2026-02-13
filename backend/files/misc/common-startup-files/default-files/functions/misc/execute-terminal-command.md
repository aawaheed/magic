# Function; Execute Terminal command
FUNCTION ==> execute-terminal-command

The following function can be used to execute a terminal command.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/execute-terminal-command.hl]:
{
  "command": "[STRING_VALUE]",
  "args": "[STRING_VALUE]",
  "working-directory": "[STRING_VALUE]"
}
___

Arguments;

- `command` is mandatory and the command to execute.
- `args` is the optional arguments as a single string to the command.
- `working-directory` is optional working directory from where to execute the command from.
