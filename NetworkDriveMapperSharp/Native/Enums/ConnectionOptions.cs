﻿namespace NetworkDriveMapperSharp.Native.Enums;

[Flags]
public enum ConnectionOptions
{
    NONE = 0x0,

    /*
        The network resource connection should be remembered.

        If this bit flag is set, the operating system automatically attempts to restore the connection when the user logs on.

        The operating system remembers only successful connections that redirect local devices. It does not remember connections that are unsuccessful or deviceless connections. (A deviceless connection occurs when the lpLocalName member is NULL or points to an empty string.)

        If this bit flag is clear, the operating system does not try to restore the connection when the user logs on.
     */
    CONNECT_UPDATE_PROFILE = 0x00000001,

    /*
		The network resource connection should not be put in the recent connection list.

		If this flag is set and the connection is successfully added, the network resource connection will be put in the recent connection list only if it has a redirected local device associated with it.
     */
    CONNECT_UPDATE_RECENT = 0x00000002,

    /*
		The network resource connection should not be remembered.

		If this flag is set, the operating system will not attempt to restore the connection when the user logs on again.
     */
    CONNECT_TEMPORARY = 0x00000004,

    /*
		If this flag is set, the operating system may interact with the user for authentication purposes. 
     */
    CONNECT_INTERACTIVE = 0x00000008,

    /*
		This flag instructs the system not to use any default settings for user names or passwords without offering the user the opportunity to supply an alternative. This flag is ignored unless CONNECT_INTERACTIVE is also set.
     */
    CONNECT_PROMPT = 0x00000010,

    /*
		 This flag forces the redirection of a local device when making the connection.
		 If the lpLocalName member of NETRESOURCE specifies a local device to redirect, this flag has no effect, because the operating system still attempts to redirect the specified device.
		 When the operating system automatically chooses a local device, the dwType member must not be equal to RESOURCETYPE_ANY.
		 If this flag is not set, a local device is automatically chosen for redirection only if the network requires a local device to be redirected.
		 
		 Windows Server 2003 and Windows XP:  When the system automatically assigns network drive letters, letters are assigned beginning with Z:, then Y:, and ending with C:.
		 This reduces collision between per-logon drive letters (such as network drive letters) and global drive letters (such as disk drives). Note that earlier versions of Windows assigned drive letters beginning with C: and ending with Z:.
	 */
    CONNECT_REDIRECT = 0x00000080,

    /*
	    If this flag is set, then the operating system does not start to use a new media to try to establish the connection (initiate a new dial up connection, for example). 
     */
    CONNECT_CURRENT_MEDIA = 0x00000200,

    /*
		If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical user interface (GUI).
		This flag is ignored unless CONNECT_INTERACTIVE is also set.
		
		Windows XP:  This value is supported on Windows XP and later.
     */
    CONNECT_COMMANDLINE = 0x00000800,

    /*
		If this flag is set, and the operating system prompts for a credential, the credential should be saved by the credential manager.
		If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving credentials, this flag is ignored.
		This flag is ignored unless CONNECT_INTERACTIVE is also set. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.
		
		Windows XP:  This value is supported on Windows XP and later.
     */
    CONNECT_CMD_SAVECRED = 0x00001000,

    /*
		If this flag is set, and the operating system prompts for a credential, the credential is reset by the credential manager.
		If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving credentials, this flag is ignored.
		This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.
		
		Windows Vista:  This value is supported on Windows Vista and later.
     */
    CONNECT_CRED_RESET = 0x00002000
}