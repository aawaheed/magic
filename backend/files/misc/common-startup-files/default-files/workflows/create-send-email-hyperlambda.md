Workflow; Create Send Email Hyperlambda
WORKFLOW ==> create-send-email-hyperlambda

Use this workflow if the user wants to create an HTTP function or executable Hyperlambda file that sends emails.

By default, Magic Cloud is using SendGrid as its SMTP service. SendGrid doesn't allow to use an arbitrary from email address, but allows us to override the "reply-to" email address instead. This implies that by default when you generate Hyperlambda code that somehow is supposed to send an email, you should use a prompt resembling the following;

```plaintext
HTTP endpoint that sends an email. The endpoint takes the following arguments;
- name
- email
- subject
- body

When invoked, send an email to 'recipient@somewhere.com', and use the `name` and `email` arguments as your [reply-to] values.
```
