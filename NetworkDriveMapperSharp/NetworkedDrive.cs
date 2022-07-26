using NetworkDriveMapperSharp.Native.Enums;
using NetworkDriveMapperSharp.Native.Externs;
using NetworkDriveMapperSharp.Native.Structs;

namespace NetworkDriveMapperSharp;

public static class NetworkedDrive
{
    /// <summary>
    /// Maps a network drive to the machine
    /// </summary>
    /// <param name="sDriveLetter">The drive letter to map the drive as. Expected format as single char</param>
    /// <param name="sNetworkPath">Path to the network drive</param>
    /// <param name="username">Username if required. If option is left empty, the function makes a connection to the network resource without redirecting a local device</param>
    /// <param name="password">Password if required</param>
    /// <param name="options">Additional options, should only be used by advanced usecases</param>
    /// <returns></returns>
    public static int MapNetworkDrive(string sDriveLetter, string sNetworkPath, string username = "", string password = "", ConnectionOptions options = ConnectionOptions.NONE)
    {
        // Checks if the last character is \ as this causes error on mapping a drive.
        if (sNetworkPath.Substring(sNetworkPath.Length - 1, 1) == @"\")
        {
            sNetworkPath = sNetworkPath.Substring(0, sNetworkPath.Length - 1);
        }

        var oNetworkResource = new NETRESOURCE();
        oNetworkResource.oResourceType = ResourceType.RESOURCETYPE_DISK;
        oNetworkResource.sLocalName = sDriveLetter + ":";
        oNetworkResource.sRemoteName = sNetworkPath;

        // If Drive is already mapped disconnect the current mapping before adding the new mapping
        if (DriveHelpers.IsDriveMapped(sDriveLetter))
        {
            DisconnectNetworkDrive(sDriveLetter, true);
        }

        var returnCode = MPR.WNetAddConnection2(ref oNetworkResource,
                    (string.IsNullOrEmpty(username) ? null : username)!,
                    (string.IsNullOrEmpty(password) ? null : password)!,
                    (int) options);
        
        return returnCode;
    }

    /// <summary>
    /// Disconnects a network drive
    /// </summary>
    /// <param name="sDriveLetter">Driveletter to disconnect. Expected input is a single char</param>
    /// <param name="bForceDisconnect">Boolean value indcicating if the disconnection should happen forcefully</param>
    /// <param name="extraFlags">Advanced extra flags. Should only be used by advanced users</param>
    /// <returns></returns>
    public static int DisconnectNetworkDrive(string sDriveLetter, bool bForceDisconnect, ConnectionOptions extraFlags = ConnectionOptions.NONE)
    {
        return MPR.WNetCancelConnection2(sDriveLetter + ":", (uint) extraFlags, bForceDisconnect);
    }
}