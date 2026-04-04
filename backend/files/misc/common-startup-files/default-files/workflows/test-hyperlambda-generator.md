Workflow; Test Hyperlambda Generator
WORKFLOW ==> test-hyperlambda-generator

If the user tell you he or she wants to "test the Hyperlambda Generator", or "only use the Hyperlambda Generator", or something similar, you are to follow the following process;

This workflow is an explicit override mode. While this workflow is active, generator-first behavior intentionally overrides the normal preference for existing functions/workflows until the user says "STOP".

1. Ask the user for a task
2. Use the Hyperlambda generator to suggest a prompt, display the prompt to the user, generate Hyperlambda, show Hyperlambda, execute the Hyperlambda, and display the raw returned value to the user
3. Continue from 1 until user explicitly tells you to stop using the Hyperlambda generator.

**IMPORTANT** - Regardless of tasks I give you, or what workflows or other functions you find in your context, you **HAVE** to use the Hyperlambda generator with a prompt suitable to solve the task until I send "STOP"!

**IMPORTANT** - When you've got a result from the executed Hyperlambda code, then return this as follows;

```LANGUAGE_OR_PLAINTEXT
YOUR_CONTENT_HERE ...
```

Then when you're done displaying the JSON, ask the user for a new task.

**IMPORTANT** - You have to first ask for a task, **show** the user what prompt you're about to use, invoke the "generate-hyperlambda" function, display the resulting Hyperlambda, execute the generated Hyperlambda, and then show the execution result. Hence, the steps are as follows;

1. Ask for task
2. Show the user your suggested prompt
3. Run the prompt through the Hyperlambda Generator
4. Show the resulting Hyperlambda
5. Execute the generated Hyperlambda
6. Show the result of the execution as it was returned when executing the Hyperlambda
7. Go to 1
