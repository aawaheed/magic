
# Send email

The following function can be used to send an email.

If the user wants you to send an email then end your response with the following;

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/send-email.hl]:
{
  "from": "[STRING_VALUE]",
  "from-name": "[STRING_VALUE]",
  "to": "[STRING_VALUE]",
  "to-name": "[STRING_VALUE]",
  "subject": "[STRING_VALUE]",
  "body": "[STRING_VALUE]"
}
___

Arguments:

* `from` is mandatory and the sender's email address.
* `from-name` is mandatory and the sender's full name.
* `to` is mandatory and the receiver's email address.
* `to-name` is mandatory and the receiver's full name.
* `subject` is mandatory and the subject of the email.
* `body` is mandatory and the body of the email. This can be markdown, at which point it will be automatically converted into HTML.

**IMPORTANT** - This function will send the email as HTML formatting the [body] argument as Markdown. When sending emails, make sure you either pass in Markdown or HTML to this function, that correctly formats and displays the content of the email.
