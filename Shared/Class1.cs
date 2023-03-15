namespace Shared;

public static class ConfigurationProvider
{
    public static string GetGamePath(OperatingSystem operatingSystem)
    {
        if (OperatingSystem.IsLinux())
        {
            return "";
        }

        if (OperatingSystem.IsWindows())
        {
            return "";
        }

        return "";
    }
}