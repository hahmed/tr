# tr - Template Renderer

Ecrion template rendering web service

https://www.ecrion.com/products/xfrenderingserver/overview

I needed a template renderer using Ecrion rendering service on the .net framework 4.5 (well 4.5.2) as the current
web service provied by Ecrion can only be installed on .net Framework 2.0, which will not work on Windows server
2012 R2.

## Building tr

Ecrion do not provide a nuget package, so a hard reference to the dll's are needed.

Assume you have the server license, so you need to install the relevant version of Ecrion on your server and machine 
(to build this project)

NOTE: Use this project as a guideline to build your web service.

If you have a version other than 11.5 (which is the version this project uses), update your reference to the dll's.

Then hit that build button!

## What's next?

Use the wcf service or the HTTP service to render those templates.

You may want to customize the index page.

You may run into an issue with the size of your file - maxReceivedMessageSize will need to be updated.

Note: If you want to create a console application to test out your webservice, make sure to update the 
*maxReceivedMessageSize* to be the same as on the server and client.

Please send PR's for any improvements.

Happy rendering!
