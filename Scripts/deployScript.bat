lpwd
lls

# Automatically answer all prompts with "no" so as not to stall the script.
option batch on

# Don't ask if we want to overwrite files on the server.
option confirm off

# Force binary mode transfer.
option transfer binary

# Connect to the web server using the saved WinSCP session.
open LANdrop

# Upload the build.
cd /home/phillco/landrop.net/downloads
put LANdrop\bin\Publish\LANdrop.exe

# Upload the version info.
cd /home/phillco/landrop.net/version
put version.json

# Disconnect and quit.
close
exit