using System.Runtime.InteropServices;
using NetworkDriveMapperSharp.Native.Enums;

namespace NetworkDriveMapperSharp.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct NETRESOURCE
{
    public ResourceScope oResourceScope;
    public ResourceType oResourceType;
    public ResourceDisplayType oDisplayType;
    public ResourceUsage oResourceUsage;
    public string sLocalName;
    public string sRemoteName;
    public string sComments;
    public string sProvider;
}