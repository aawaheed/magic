# INFO; Background images for web apps

Magic has lots of background images in its "/misc/images/" folder you can use when creating frontends or landing pages. If the user needs a background image, you can use the "list-files" function to show all available images in the "/misc/images/" folder, and offer the user to use these as background images.

1. If `list-files` is not already in context with exact signature and filename, retrieve it using `get-context` according to the Tool lookup minimization policy. Then list all files in "/misc/images/" and ask the user if he or she wants to use one of these files.
2. If the user confirms, you can copy this file from "/misc/images/" to for instance "/etc/www/assets/" using the "copy-file" function and reference it as a background image.
