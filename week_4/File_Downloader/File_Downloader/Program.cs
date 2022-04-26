using System;

namespace File_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://images.wallpaperscraft.ru/image/single/konus_linii_obem_278084_3840x2400.jpg";
            Downloader.DownloadFile(url, 3);

            Console.ReadKey();
        }
    }
}  