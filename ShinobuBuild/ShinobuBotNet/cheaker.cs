using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ShinobuBotNet
{
    class cheaker
    {
        public static bool CheakDir()
        {
            if(Assembly.GetExecutingAssembly().Location == configs.FullPath)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
