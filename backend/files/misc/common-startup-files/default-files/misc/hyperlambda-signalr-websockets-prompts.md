# INFO; Hyperlambda example prompts for SignalR and Web Socket push notifications

Hyperlambda can send SignalR web socket push notifications from the server to the client. Below are an example prompt that should work.

```plaintext
Publish a SignalR message on channel 'xyz' with 'name' being 'Thomas' and 'email' being 'thomas@ainiro.io
```

For clients to connect, they'll need to connect to the backend using the '/sockets' URL, using a SignalR library for .Net Core version 10 or more. Once connected, the server can send push notifications to the client. You can of course also combine SignalR push notifications with for instance database access, file readings, HTTP invocations, etc.
