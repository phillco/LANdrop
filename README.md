LANdrop
=======

**LANdrop** is a fast, dead-simple utility to send files to people over LAN. No registration, no IP addresses, no cloud...just open the dialog, drag the file over to their name, and you're done!

LANdrop started as a small [student project](https://github.com/phillco/jLANdrop), but it was so useful that we've decided to expand and release it. We're rewriting it in C# to build a killer UX, but the protocol will be open to allow other native clients, too.

This version is currently under development and isn't really usable yet.



Roadmap
=============

**Note:** Move these items to issues whenever possible.

* Create a SQLite database where Peers and FileCaches may be stored over time.
* Hammer out the different peer sources (Multicast, PeerExchange, ManuallyAdd, Clipboard), and figure out the process for each's development.
    * Fix peer activity icons
* Automatically analyze IPs that are copied to the clipboard
* Settings...
    * Let the user set the downloads directory.
    * Let the user to enable file logs as well as to set the log directory.
* Implement an "always accept transfers from this user" system using RSA keys to ensure somebody's identity.    
    * For now, save the client's RSA private key in the Configuration file. We can encrypt it using a basic password (eg, "LANdrop") so that at least file sniffers won't see it - but anyone who knows that password (anyone with the source, obviously) can decrypt it - but that should suffice for most users.
        * Maybe we can add an option later that encrypts the private key with a passphrase, which much be entered at startup.
* Encrypted transfers - encrypt all data in transit. Sender creates a shared session key, encrypts with receiver's public key.
* Rewrite protocol to use JSON and/or ProtoBuff for cross-platform compatibility
* Drop Codes - a simple password that you can set; anyone with the password can send you a file without having to wait for you to accept it (also useful for sending files for yourself).
* Log off, shut down, or hibernate after transfer is complete. 
* Automatically resume an earlier transfer that failed (receiver reads to end of what it's got, sends byte count and checksum)
* Automatic updating, Chrome-style.
* Automatic exception reporting.
* Instead of opening a new window for every transfer, create a "transfers" window.
* Sending multiple files.
* Sending to multiple recipients.
* Command line version!
* Tray icon, run at startup.
* Ways to block unwanted peers.
* Support for transferring files that are *themselves* being transferred. That way you can start a download on one computer and stream it to another.
* Statistics - number of transfers failed, succeeded, bytes transferred, average speed. Stats on website. For fun, all opt-in.


Credits
=========

Developed by Phillip Cohen. Icons from the excellent [FatCow Icons Pack](http://www.fatcow.com/free-icons).

