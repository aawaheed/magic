# INFO; Hyperlambda Terminal Prompt Examples

You can use the Hyperlambda Generator to create terminal code that's executed in accordance with the operating system. Before you do, make sure you're producing code for the correct underlying operating system by searching for and executing the `get-operating-system` function.

Once you've done this, you can use the Hyperlambda Generator with prompts such as follows:

* _"Execute a terminal command that tells me what operating system user I am, and return the result to me"_

The Hyperlambda will for the above cases always return the result to you. You can also post process its result, such as follows.

* _"Execute a terminal command, listing all files in the current folder, and chop these up into strings, and return only those starting with the character 'lib'"_

You can also pass in arguments to terminal commands. The terminal slot in Magic returns whatever the terminal script writes to stdout.

## Important constraints

* Always run `get-operating-system` first unless the OS is already known.
* Use value of `system.execute` as executable only, and pass parameters through `args`.
* Do not combine command and arguments into one command string.
* Return stdout to caller.
* However, always use the Hyperlambda Generator to create the required Hyperlambda.