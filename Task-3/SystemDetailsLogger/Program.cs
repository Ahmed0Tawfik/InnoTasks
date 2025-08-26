namespace SystemDetailsLogger;


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Logger Started...");
        Logger logger = new Logger();
        logger.StartLoggingInfo();
    }
}
