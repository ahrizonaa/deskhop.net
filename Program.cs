using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.IO;

namespace Desktop
{
    class Deskhop
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        private static readonly string CENTER = "0";
        private static readonly string TILE = "1";
        private static readonly string STRETCH = "2";
        private static readonly string FIT = "3";
        private static readonly string FILL = "4";
        private static readonly string SPAN = "5";

        static void Main(string[] args)
        {
            string imgpath = args[0];

            if (File.Exists(imgpath))
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                key.SetValue(@"WallpaperStyle", FILL);
                key.SetValue(@"TileWallpaper", "0");


                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imgpath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }
    }
}