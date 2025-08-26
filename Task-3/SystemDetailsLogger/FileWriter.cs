namespace SystemDetailsLogger;

public class FileWriter
{
    
    private static readonly string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //get the user documents folder instead of hardcoding 
    private readonly string filePath = Path.Combine(documentsPath, "SystemLogs.txt");
    // safely combines paths to avoid problems like unauthorized file traversal injection etc...


    public FileWriter()
    {
        // Ensure file exists
        if (!File.Exists(filePath))
        {
            using (File.Create(filePath)) { }
        }
    }
    public void WriteInfo(string info)
    {
        File.AppendAllText(filePath, info + Environment.NewLine);
    }
}
