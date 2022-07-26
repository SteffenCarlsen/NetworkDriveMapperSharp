namespace NetworkDriveMapperSharp;

public static class DriveHelpers
{
    public static bool IsDriveMapped(string driveLetter)
    {
        var driveList = Environment.GetLogicalDrives();
        foreach (var letter in driveList)
        {
            if (driveLetter + ":\\" == letter)
            {
                return true;
            }
        }

        return false;
    }
}