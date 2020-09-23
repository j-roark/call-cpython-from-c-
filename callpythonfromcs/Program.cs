using System;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        // full path of the local python interpreter 
        string python = @"C:\Program Files\WindowsApps\PythonSoftwareFoundation.Python.3.7_3.7.2032.0_x64__qbz5n2kfra8p0\python.exe";

        // name of python app to call 
        string pyScript = @"pytest.py";

        var myProcessStartInfo = new ProcessStartInfo(python)
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            Arguments = pyScript
        };

        Process myProcess = new Process
        {
            StartInfo = myProcessStartInfo
        };

        Console.WriteLine("Calling Python script with no arguements:");

        using var process = Process.Start(myProcessStartInfo);
        {

            process.OutputDataReceived += Process_OutputDataReceived;
            process.BeginOutputReadLine();
            process.WaitForExit();
            Console.WriteLine("Process closed");

            static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine(e.Data);
            }
        }
    }
}
