using NetworkDriveMapperSharp.Native.Enums;
using NetworkDriveMapperSharp.Native.Externs;
using NetworkDriveMapperSharp.Native.Structs;

namespace NetworkDriveMapperSharp;

public static class NetworkedDrive
{
    public static void MapNetworkDrive(string sDriveLetter, string sNetworkPath, string username = "", string password = "", ConnectionOptions options = ConnectionOptions.NONE)
    {
        //Checks if the last character is \ as this causes error on mapping a drive.
        if (sNetworkPath.Substring(sNetworkPath.Length - 1, 1) == @"\")
        {
            sNetworkPath = sNetworkPath.Substring(0, sNetworkPath.Length - 1);
        }

        var oNetworkResource = new NETRESOURCE();
        oNetworkResource.oResourceType = ResourceType.RESOURCETYPE_DISK;
        oNetworkResource.sLocalName = sDriveLetter + ":";
        oNetworkResource.sRemoteName = sNetworkPath;

        //If Drive is already mapped disconnect the current 
        //mapping before adding the new mapping
        if (IsDriveMapped(sDriveLetter))
        {
            DisconnectNetworkDrive(sDriveLetter, true);
        }

        MPR.WNetAddConnection2(ref oNetworkResource, (string.IsNullOrEmpty(username) ? null : username)!, (string.IsNullOrEmpty(password) ? null : password)!, (int) options);
    }
    
    public static int DisconnectNetworkDrive(string sDriveLetter, bool bForceDisconnect)
    {
        if (bForceDisconnect)
        {
            return MPR.WNetCancelConnection2(sDriveLetter + ":", 0, 1);
        }
        else
        {
            return MPR.WNetCancelConnection2(sDriveLetter + ":", 0, 0);
        }
    }
    
    public static bool IsDriveMapped(string sDriveLetter)
    {
        string[] DriveList = Environment.GetLogicalDrives();
        for (int i = 0; i < DriveList.Length; i++)
        {
            if (sDriveLetter + ":\\" == DriveList[i].ToString())
            {
                return true;
            }
        }
        return false;
    }
}