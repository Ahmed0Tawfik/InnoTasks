namespace SystemDetailsLogger;

public class Logger
{
    protected readonly SystemManagementService systemManagementService = new();
    protected readonly FileWriter fileWriter = new();
    public void StartLoggingInfo()
    {
        while (true)
        {
            string info = systemManagementService.GetPeriodicInfo();
            string dateTimeNow = DateTime.Now.ToString();
            info = $"{dateTimeNow}\n{info}";

            //Console.WriteLine(info);

            fileWriter.WriteInfo(info);

            Thread.Sleep(60 * 1000);
        }
    }
}
