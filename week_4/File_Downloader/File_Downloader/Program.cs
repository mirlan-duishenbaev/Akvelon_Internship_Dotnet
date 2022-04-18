using System;

namespace File_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://images.wallpaperscraft.ru/image/single/teplohod_more_gory_274897_1920x1080.jpg";
            var result = Downloader.Download(url, @"c:\temp\", 3);

            Console.WriteLine($"Location: {result.FilePath}");
            Console.WriteLine($"Size: {result.Size}bytes");
            Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
            Console.WriteLine($"Parallel: {result.ParallelDownloads}");

            Console.ReadKey();
        }
    }
}  