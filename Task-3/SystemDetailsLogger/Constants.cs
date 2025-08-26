namespace SystemDetailsLogger;


public static class WmiClassNames
{
    public const string CPU = "Win32_Processor";
    public const string RAM = "Win32_PhysicalMemory";
    public const string LogicalDisk = "Win32_LogicalDisk";
    public const string DiskDrive = "Win32_DiskDrive";
    public const string OperatingSystem = "Win32_OperatingSystem";
    public const string NetworkAdapter = "Win32_NetworkAdapter";
    public const string NetworkAdapterConfiguration = "Win32_NetworkAdapterConfiguration";
    public const string GPU = "Win32_VideoController";
    public const string BIOS = "Win32_BIOS";
    public const string ComputerSystem = "Win32_ComputerSystem";
    public const string Service = "Win32_Service";
    public const string StartupCommand = "Win32_StartupCommand";
    public const string Process = "Win32_Process";
    public const string Environment = "Win32_Environment";
    public const string UserAccount = "Win32_UserAccount";
    public const string Group = "Win32_Group";
    public const string Product = "Win32_Product";
}
