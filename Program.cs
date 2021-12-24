using System.Diagnostics;

class Program
{ 
    static void Main()
    {
        Console.Title = "Watchdog";
        Console.WriteLine("Set period (in second) to check if app is running." + Environment.NewLine); 
        string period = Console.ReadLine();
          
        new Timer(CheckProcess, null, 0, int.Parse(period) * 1000);
        Thread.Sleep(Timeout.Infinite);
    }

    static void CheckProcess(object obj)
    {
        try
        {
            bool isRunning = false;
            foreach (Process process in Process.GetProcesses().Where(p => p.ProcessName.ToLower() == "python"))
            {
                isRunning = true;
            }

            if (!isRunning)
            {
                Process.Start("cmd.exe","/C python index.py");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}