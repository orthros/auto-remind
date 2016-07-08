# auto-remind
Inspired by the man who used shell scripts to automate his life.
https://github.com/NARKOZ/hacker-scripts

I decided to look at enhancing his idea to automatically text
his wife when he is logged in too late and made a C# program that
allowed you to configure a set of conditions that, when met,
would prompt you to send a message to a predefined recipient.

There is clearly still work to be done. Right now, only
time-based triggers are supported, and I would like to
include process based triggers. For example:

    If it is past 17:00 and more than two instances of
    devenv.exe (Visual Studio) are running, then
    Text Alice that I will be home late

This is, however a "minimum viable product" for the current
goals it has set out.

To get this to work properly, you will need a Twilio account
and configure its keys as appropriate in the app.config

```xml
<appSettings>
  <add key="twilio-auth-key" value="XXXXXX"/>
  <add key="twilio-auth-token" value="XXXXXX"/>
  <add key="twilio-from-number" value="XXXXXX"/>
</appSettings>
```
Right now this works only on Windows, but I would eventually like
to write the entire application cross platform in Electron
 (.NET Core would be cool, but they don't have proper hooks into 
native UI elements)
