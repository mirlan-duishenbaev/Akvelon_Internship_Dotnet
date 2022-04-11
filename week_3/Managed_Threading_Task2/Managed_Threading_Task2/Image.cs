using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Managed_Threading_Task2
{
    internal class Image
    {
        public string? AlbumId { get; set; }
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? ThumbnailUrl { get; set; }

        private static object locker = new();

        public static List<Image> CreateImageList(string url)
        {
            var json = new WebClient().DownloadString(url);
            dynamic imageList = JValue.Parse(json);
            List<Image> list = new List<Image>();

            foreach (var item in imageList)
            {
                Image image = new()
                {
                    AlbumId = item.albumId,
                    Id = item.id,
                    Title = item.title,
                    Url = item.url,
                    ThumbnailUrl = item.thumbnailUrl,
                };
                list.Add(image);
            }
            return list;
        }

        public static void DownloadImage(string url, string fileName)
        {
            lock (locker)
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(url, fileName);
                    Console.WriteLine("{0} | Thread {1} starts downloading image {2}",
                    DateTime.Now.ToString("hh:MM:ss"),
                    Thread.CurrentThread.ManagedThreadId, fileName);
                }
            }
        }
    }
}
