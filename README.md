LANdrop
=======

**LANdrop** is a fast, dead-simple utility to send files to people over LAN. No registration, no IP addresses, no cloud...just open the dialog, drag the file over to their name, and you're done!

LANdrop started as a small [student project](https://www.assembla.com/wiki/show/p2pfiletransfer), but it was so useful that we've decided to expand and release it. We're rewriting it in C# to build a killer UX, but the protocol will be open to allow other native clients, too.

This version is currently under development and isn't really usable yet.



Roadmap
=============

* The transfers themselves.
* Determine if multicasting works across different subnets.
    * If not, create a system to enter and store IPs manually.
        * Consider also creating an system for LANdrop peers to automatically share IP addresses - that way if there's a client "out of the loop" on a faraway subnet, adding him manually on one computer will bring him into the loop - he'll see *all* the other peers on the network, and vice-versa.
* Fancy "incoming transfer" notifications - kind of like Outlook 2003's "new mail" box. Much better than MessageBox()es. 
* Automatically save all transfers in a certain directory (faster than prompting each time). Let the user change where a transfer is being saved once it's started - doing so will submit a request to move it once it's done downloading.
* Drop Codes - a simple password that you can set; anyone with the password can send you a file without having to wait for you to accept it (also useful for sending files for yourself).
* Log off, shut down, or hibernate after transfer is complete. 
* Command line version!
* More reliable transfers...
    * Resume an earlier transfer (receiver reads to end of what it's got, sends byte count and checksum)
    * Automatically detect broken transfer and resume
* Automatic updating, Chrome-style.
* Automatic exception reporting.
* Instead of opening a new window for every transfer, create a "transfers" window.
* Sending multiple files.
* Sending to multiple recipients.
* Tray icon, run at startup.
* Encrypted transfers - encrypt all data in transit. Sender creates a shared session key, encrypts with receiver's public key.
* Identity verification (otherwise anyone can give themselves your name). Maybe something with a public key web-of-trust?
* Support for transferring files that are *themselves* being transferred. That way you can start a download on one computer and stream it to another.