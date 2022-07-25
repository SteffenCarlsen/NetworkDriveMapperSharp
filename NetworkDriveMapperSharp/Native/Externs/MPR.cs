using System.Runtime.InteropServices;
using NetworkDriveMapperSharp.Native.Structs;

namespace NetworkDriveMapperSharp.Native.Externs;

public static class MPR
{
    [DllImport("mpr.dll")]
    public static extern int WNetAddConnection2
    (ref NETRESOURCE oNetworkResource, string sPassword, 
        string sUserName, int iFlags);
    
    [DllImport("mpr.dll")]
    public static extern int WNetCancelConnection2
        (string sLocalName, uint iFlags, int iForce);
}