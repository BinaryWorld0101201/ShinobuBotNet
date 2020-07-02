using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShinobuBotNet
{
    class check
    {
        public static bool CheckDir()
        {
            if (Application.ExecutablePath == config.InstallPath)
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
