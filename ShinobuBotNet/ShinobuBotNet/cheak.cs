using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShinobuBotNet
{
    class cheak
    {
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

    }
}
