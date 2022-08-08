using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wallhaven_Random_Wallpaper.Methods
{
    internal static class Wallpaper
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        public static void SetWallpaperFromQuery(string path, string apiQuery)
        {
            using (var client = new WebClient())
            {
                path += new Guid().ToString() + ".png";
                //TemperaturesOperations getData = new TemperaturesOperations(apiQuery);
                //client.DownloadFile(new Uri(getData.GetRandomObject().Path.ToString().Replace(@"\", String.Empty)), path);


                // for testing on small resolution
                TemperaturesOperations getThumb = new TemperaturesOperations(apiQuery);
                client.DownloadFile(new Uri(getThumb.GetRandomObject().Thumbs.Small.ToString().Replace(@"\", String.Empty)), path);


                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }
    }
}
