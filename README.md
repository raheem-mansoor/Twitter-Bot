# Twitter-Bot
Twitter-Bot written in C# using TweetSharp. Sends a tweet everyday at sunrise/sunset according to current location.

made by Raheem Mansoor and Peter Ebsen. 


# Instructions to install:

1. Go to Twitter Developer and sign in using the Twitter account you want to use the bot with.

2. Once you are signed in go into the Developer Portal and create a new App/Project.

3. When you are done creating the app go to the settings of the app and genereate/view keys
   There should be the following keys for you to be revealed:
   API Key: ""
   API Secret Key: ""
   Access Token: ""
   Access Token Secret: ""
   
4. Copy each Key/Token and paste it into the Twitter-Bot v.2.1.sln File. (Leave the "" and copy the code in between!)
   You can open this file with any Text-Editor of your choich. I recommend you to use Atom or Sublime Text
   
5. After pasting the Keys and tokens into their correct position you can save the file. 

6. Now you can start the Twitter-Bot v.2.1.exe File (located under Twitter-Bot v.2.1\bin\Debug).

7. This will open a Executable File which contains a console application. The further Instruction is given in the application itself.



# Relevant informations

The bot needs to be open to correctly send both tweets (sunrise/sunset).
Once a Tweet has been sent successfully the console will give you a feedback saying "... - Tweet sent".


You are getting the Error Message "Status is a duplicate" -> Than you opened the bot after sunrise, so only the sunset Tweet of the specific Day will be sent.



