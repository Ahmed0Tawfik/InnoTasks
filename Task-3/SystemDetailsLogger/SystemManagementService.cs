namespace SystemDetailsLogger;

public class SystemManagementService
{
    public string GetInfo(string metricName, string component)
    {
        using(var searcher = new ManagementObjectSearcher($"SELECT * FROM {component}"))
        {
            var result = string.Empty;

            foreach (var _component in searcher.Get())
            {
                // treat it like hashtable instead of for nested loops

                var property = (PropertyData)(_component.Properties[$"{metricName}"]);

                result = $"{component}:{property.Name}:{property.Value}{result}\n";
            }
            return result;
        }
    }

    public string GetPeriodicInfo()
    {
        string ramCapacity = GetInfo("Capacity", WmiClassNames.RAM);
        string FreePhysicalMemory = GetInfo("FreePhysicalMemory", WmiClassNames.OperatingSystem);
        // cpu temp is not accessable due to security issues on win10/11 
        //string cpuTemp = GetInfo("CurrentTemperature",WmiClassNames.CPU);
        string numOfCores = GetInfo("NumberOfCores", WmiClassNames.CPU);
        string cpuUsage = GetInfo("LoadPercentage", WmiClassNames.CPU);
        
        string diskSerialNumber = GetInfo("SerialNumber", WmiClassNames.DiskDrive);
        

        string result = $"{ramCapacity}{FreePhysicalMemory}{numOfCores}{cpuUsage}{diskSerialNumber}";

        return result;
    }
    

}
