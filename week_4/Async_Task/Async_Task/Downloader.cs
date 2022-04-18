using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Async_Task
{
    internal class Downloader
    {
        public static void RunDownloadImage(string url, string fileName)
        {
            DownloadImage(url, fileName);
        }

        private static void DownloadImage(string url, string fileName)
        {
            var download = Task.Run(() =>
            {
                using WebClient webClient = new WebClient();
                webClient.DownloadFile(url, fileName);
            });

            try
            {
                Task.WaitAll(download);
                Console.WriteLine("Image has been downloaded!");
            }
            catch (AggregateException ae)
            {
                foreach (var item in ae.Flatten().InnerExceptions)
                {
                    Console.WriteLine("Exception is:" + item.Message);
                }
            }
        }
    }
}
