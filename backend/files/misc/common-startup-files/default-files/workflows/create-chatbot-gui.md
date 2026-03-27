Workflow; Create chatbot GUI
WORKFLOW ==> create-chatbot-gui

Use this workflow if the user wants to create a frontend chat GUI for an existing AI chatbot type in the backend.

The purpose of the chat GUI is to send prompts to the backend's `[BACKEND_URL]/magic/system/openai/chat` endpoint, optionally stream tokens back to the UI using SignalR, render references if requested, support persisted sessions, and optionally support chat history and file uploads.

A chatbot type is simply a machine learning type in the backend. If the user does not know which chatbot type to use, you should search for the function to list machine learning types using the `get-context` function, and then use that function to show the available types to the user.

Before you begin you need to ask the user the following questions:

1. Ask the user for the AI chatbot type to use.
   - This becomes the `type` argument sent to the backend chat endpoint.
   - If the user does not know which type to use, retrieve the function for listing machine learning types using `get-context` and use it to show the available types.
2. Ask the user if the GUI should use streaming or not.
   - If streaming is enabled, the frontend must use SignalR and subscribe to the specified session channel before invoking the chat endpoint. The session argument can be a random string generated when the user starts his chat session.
3. Ask the user if conversations should be persisted.
   - If yes, the frontend must send `permanent = true`.
4. Ask the user if references should be shown in the UI.
   - If yes, the frontend must send `references = true` and render the `references` array returned from the backend returned from the HTTP POST invocation.
5. Ask the user if file uploads should be supported.
   - If yes, the frontend must submit uploaded files as `file` arguments when invoking the chat endpoint using `multipart/form-data`.
6. Ask the user if the frontend should show previous sessions.
   - If yes, the frontend should use the history endpoints to list and load persisted conversations.
7. Ask the user if the frontend should deal with follow up questions.
   - If yes, then correctly implement the follow up questions parts further down in this document.

When you have all the required information from the user then continue the process until done.

## Important facts about the backend chat endpoint

The backend chat endpoint is a POST endpoint accepting arguments resembling the following.

1. `prompt`
2. `type`
3. `session`
4. `stream`
5. `permanent`
6. `references`
7. `user_id`
8. `recaptcha_response`
9. `data`
10. `meta`
11. `extra`
12. `system_message_override`
13. `file`

The `prompt` and `type` arguments are mandatory.

The `session` argument is important because it is used for the server side chat session cache, for persisted history, and as the SignalR channel name when streaming is enabled.

If the frontend creates a new conversation, it can generate the `session` value itself as a random string. The same `session` value should then be re-used for the whole conversation.

If `stream = true` then the backend immediately starts a background OpenAI request and sends incremental updates to the frontend using `sockets.signal` on the specified `session`. This means the frontend must establish the SignalR subscription first, and only then invoke the chat endpoint.

If `stream = false` then the backend returns the final result directly in the HTTP response.

If `permanent = true` then the backend stores the conversation in persisted history.

If `references = true` and the chatbot type uses embeddings, the backend may return a `references` collection containing relevant sources that should be rendered below the assistant message.

If `file` is supplied then the backend can send images and PDF files to the model as part of the current user message. If files are attached, the frontend must use `multipart/form-data` when invoking the chat endpoint. If no files are attached, the frontend can invoke the exact same endpoint using a regular JSON payload. The backend does not depend upon a single fixed `Content-Type` here, and can accept both form-data and JSON payloads.

## Required frontend flow

The frontend should implement the following sequence whenever the user sends a message.

1. Create or re-use a `session` value.
   - If this is a new conversation you should create a random session ID in the frontend.
   - Re-use the same session ID for the whole conversation.
2. If streaming is enabled, connect to SignalR first.
   - Subscribe to messages for the current `session`.
   - Make sure the SignalR connection is ready before invoking the chat endpoint.
3. Invoke the backend chat endpoint using POST.
   - Send `prompt`, `type`, `session`, and `stream`.
   - Also send `permanent`, `references`, `user_id`, `meta`, `extra`, `data`, `system_message_override`, and `file` only if required.
   - Use `multipart/form-data` if files are attached.
   - Use JSON if no files are attached.
4. Immediately render the user's message in the UI.
5. Render the assistant response.
   - If streaming is disabled, render the `result` field from the HTTP response.
   - If streaming is enabled, progressively append message fragments received from SignalR.
6. If the backend returns `references`, render them below the assistant message.
7. If the backend signals completion, stop the typing state and finalize the assistant message.

## SignalR streaming rules

When streaming is enabled the frontend must listen for incremental SignalR payloads on the current `session`.

The frontend should handle the following kinds of messages.

1. `message`
   - Append this text fragment to the currently streaming assistant message.
2. `finish_reason`
   - Store it on the current assistant message if needed.
3. `finished`
   - Mark the assistant response as done and stop the loading indicator.
4. `error`
   - Show the error message to the user and stop the loading indicator.
5. `function_waiting`
   - Optionally show a temporary status such as "Working..." while the backend executes an AI function.
6. `function_result`
   - Optionally show a temporary status indicating that a backend function completed.
7. `function_error`
   - Optionally show that a backend function failed.

Notice, the frontend must not wait for streamed HTTP body chunks from the POST response. The streaming updates come through SignalR, not through the HTTP response body.

## Shape of SignalR messages

The backend sends small JSON objects as strings over SignalR. Each SignalR message typically contains one or a few properties only, and the frontend should inspect the properties of each incoming object to determine what it means. Notice, the backend sends this as a simple string, so the frontend needs to parse it as a JSON object before referencing fields in it.

Examples of SignalR payloads you should expect are the following.

1. Partial assistant text
   - This contains a text fragment that should be appended to the currently streaming assistant message.

```json
{
  "message": "Hello"
}
```

2. Finish reason
   - This tells the frontend why the generation stopped.

```json
{
  "finish_reason": "stop"
}
```

3. Generation finished
   - This indicates that the backend is done streaming the current assistant response.

```json
{
  "finished": true
}
```

4. Backend error
   - This should stop the loading indicator and display the error to the user.

```json
{
  "error": true,
  "status": 500,
  "message": "Something went wrong"
}
```

5. Waiting for AI function
   - This means the model emitted a function invocation and the backend is currently executing it.

```json
{
  "function_waiting": true
}
```

6. AI function succeeded
   - This can contain a generic success message, the original invocation payload, and the function file name that was executed.

```json
{
  "function_result": "Success!",
  "invocation": "{ ...json payload for function... }",
  "file": "module.folder.function"
}
```

7. AI function failed
   - This should be shown as a temporary status or as a visible error in the UI.

```json
{
  "function_error": "Function failed because ..."
}
```

The frontend should not assume that every SignalR message has a `message` field. Some messages only contain `finish_reason`, `finished`, `function_waiting`, `function_result`, `function_error`, or `error`.

If the SignalR payload contains `message`, append it to the current assistant message.

If the SignalR payload contains `function_result`, then this is not assistant text. It is metadata telling the frontend that a backend AI function succeeded. The `invocation` property contains the function invocation payload, and the `file` property contains the name of the Hyperlambda function that was executed.

If the SignalR payload contains `function_error`, then this is also not assistant text. It is an execution status message from the backend.

If the SignalR payload contains `finished = true`, then the frontend should finalize the current assistant message even if the final SignalR payload did not contain a `message`.

## JavaScript SignalR example

Below is a small JavaScript example showing one possible approach to consuming SignalR messages.

```javascript
const builder = new signalR.HubConnectionBuilder()
  .withAutomaticReconnect();

const connection = builder
  .withUrl("[BACKEND_URL]/sockets", {
    transport: signalR.HttpTransportType.WebSockets
  })
  .build();

let currentAssistantMessage = "";

connection.on(sessionId, payload => {
  if (payload.message) {
    currentAssistantMessage += payload.message;
    renderAssistantMessage(currentAssistantMessage);
  }

  if (payload.function_waiting) {
    showStatus("Executing function ...");
  }

  if (payload.function_result) {
    showStatus(payload.function_result);
    console.log("Function invocation payload:", payload.invocation);
    console.log("Function file:", payload.file);
  }

  if (payload.function_error) {
    showError(payload.function_error);
  }

  if (payload.finish_reason) {
    console.log("Finish reason:", payload.finish_reason);
  }

  if (payload.error) {
    showError(payload.message || "Unknown backend error");
    stopLoading();
  }

  if (payload.finished) {
    stopLoading();
    finalizeAssistantMessage(currentAssistantMessage);
  }
});

await connection.start();

await fetch("[BACKEND_URL]/magic/system/openai/chat", {
  method: "POST",
  headers: {
    "Content-Type": "application/json"
  },
  body: JSON.stringify({
    prompt: userPrompt,
    type: chatbotType,
    session: sessionId,
    stream: true,
    permanent: true,
    references: true
  })
});
```

Notice, the example above assumes the frontend subscribes using the `session` ID as the SignalR event name or channel name. The important part is that the frontend listens for messages on the same `session` value it sends to the backend chat endpoint.

## Suggested request payload

Below is an example payload you can use when invoking the chat endpoint if no files are attached.

{
  "prompt": "How do I reset my password?",
  "type": "[CHATBOT_TYPE]",
  "session": "[SESSION_ID]",
  "stream": true,
  "permanent": true,
  "references": true,
  "user_id": "[OPTIONAL_USER_ID]"
}

If the user uploads files, submit them as `file` arguments together with the rest of the payload using `multipart/form-data`.

## Expected response handling

If `stream = false`, the backend returns a response containing values resembling the following.

1. `result`
2. `finish_reason`
3. `db_time`
4. `stream`
5. `references` if requested and available

If `stream = true`, the immediate HTTP response mainly confirms the invocation and may include metadata such as `db_time`, `stream`, and `references`, while the actual generated text is sent over SignalR.

## Optional history support

If the user wants persisted history, the frontend should also use these endpoints.

1. History list endpoint
   - Use this to list available persisted sessions for the current user.
2. History get endpoint
   - Use this to load all messages for one persisted session.

If you implement persisted history, make sure the frontend can switch between sessions and update the active `session` value before sending a new prompt.

## UI requirements

The chat GUI should have the following elements.

1. Message list showing user and assistant messages
2. Multiline textbox for prompt input
3. Send button
4. Typing or loading indicator while waiting for response
5. Optional file upload control
6. Optional references area below assistant messages
7. Optional session history sidebar if persisted history is enabled

## Follow up questions

If the machine learning type is configured to return follow up questions, it will return something as follows at the end of its response if there are follow up questions.

```markdown
---
- Question 1
- Question 2
- Question 3
```

Notice, it can also return `*` characters instead of `-`, so you have to check for both.

If it does, these are follow up quesitons and not a part of its answer, and a button should be rendered for each of the above, allowing the user to click the button, which triggers the content of the button as a question, and immediately transmits it to backend as a user request.

## Important implementation rules

1. Always connect SignalR before invoking the chat endpoint when streaming is enabled.
2. Always send the same `session` value for the whole conversation.
3. New sessions can be created by the frontend as random strings.
4. Always append streamed fragments to the same in-progress assistant message.
5. Always handle `error` and `finished` SignalR messages so the UI does not get stuck loading.
6. Do not assume references are always returned.
7. Do not assume persisted history exists unless `permanent = true` is used.
8. If the backend requires CAPTCHA for the type, make sure the frontend collects and sends `recaptcha_response`.
   - See below for how to correctly include Magic CAPTCHA on the page.
9. If files are attached, always use `multipart/form-data`.
10. If files are not attached, the same endpoint can be invoked using JSON.

When you have all the required information from the user then continue the process until done.

## About magic CAPTCHA

Magic CAPTCHA is sometimes required on machine learning types. The frontend JavaScript file can be included using "[BACKEND_URL]/magic/system/misc/magic-captcha-challenge.js". While the frontend can implement generating a CAPTCHA token using functionlity similar to the following.

```javascript
mcaptcha.token(function (token) {
  // Pass token into the server here as `recaptcha_response`.
}.bind(this), 3);
```

**IMPORTANT** - Magic has two means to create a chatbot. It can use the existing JavaScript files, or manually create a new GUI using this workflow. If the user wants an embeddable AI chatbot, you should probably search for "Embed AI chatbot" and use that workflow instead.

**IMPORTANT** - If the user wants to follow this workflow, it implies you need to wire up everything yourself based upon the above documentation, and not reuse any of its JavaScript files, besides optionally "magic-captcha-challenge.js" if the user wants CAPTCHA support.

So you have to get the user's confirmation if he wants to follow this workflow, or simply wants to embed an existing AI chatbot. If the user wants you to create a custom GUI, you have to follow this workflow instead of the embed AI chatbot workflow.
