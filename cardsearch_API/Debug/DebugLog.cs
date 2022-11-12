using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace CardSearchApi.Debug;

public static class DebugLog
{
    // Consts
    private const string FileName = "LogFile_";
    private const string LinuxPath = "/home/";
    
    private const string WindowsPath = "c:\\Documents\\";
    
    // Private Variables
    private static string finalLogFileName = String.Empty;
    private static string userName = Environment.UserName;

    //Private Methods
    private static string CreateFileName()
    {
        if (string.CompareOrdinal(finalLogFileName, String.Empty) == 0)
        {
            DateTime dateTime = DateTime.Today;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                string user = Environment.UserName;
                finalLogFileName = LinuxPath +userName+ "/Documents/" + FileName + dateTime.Date.Day +"_"+ dateTime.Date.Month+"_"+dateTime.Date.Year;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                finalLogFileName = WindowsPath + FileName + dateTime.Date;
            }
        }

        return finalLogFileName;
    }

    private static void CreateLogFile()
    {
        if (!CheckIfLogFileAlreadyExisting())
        {
            using FileStream file = File.Create(finalLogFileName);
            
            file.Flush();
            file.Close();
        }
        else if (System.Diagnostics.Debugger.IsAttached)
        {
            File.Delete(finalLogFileName);
            
            using FileStream file = File.Create(finalLogFileName);
            
            file.Flush();
            file.Close();
        }
    }

    private static bool CheckIfLogFileAlreadyExisting()
    {
        try
        {
            return File.Exists(CreateFileName());
        }
        catch
        {
            return false;        
        }
    }

    //Public Methods
    /// <summary>
    /// This method will write the log string given to the log file
    /// </summary>
    /// <param name="logToWrite">This string will be written to the file</param>
    public static void WriteDebugLog(string logToWrite)
    {
        CreateLogFile();
        if (string.CompareOrdinal(finalLogFileName, String.Empty) != 0)
        {
            using StreamWriter writer = new StreamWriter(finalLogFileName);
            writer.WriteLine(logToWrite);
            writer.WriteLine("<==============================================>");
            writer.Flush();
            writer.Close();
        }
    } 
}