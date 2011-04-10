# Automatically answer all prompts with "no" so as not to stall the script.
option batch on

# Don't ask if we want to overwrite files on the server.
option confirm off

# Connect to the web server using the saved WinSCP session.
open phillco@philltopia.com

# Change remote directory.
cd /home/phillco/landrop.net/downloads

# Force binary mode transfer.
option transfer binary

# Upload the file to current remote working directory.
put LANdrop\bin\Release\LANdrop.exe

# Disconnect and quit.
close
exit