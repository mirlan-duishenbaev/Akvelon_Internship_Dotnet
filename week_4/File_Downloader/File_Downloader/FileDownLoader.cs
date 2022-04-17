using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Downloader
{
    internal class FileDownLoader
    {
        public static long GetFileSize(string url)
        {
            long result = -1;

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "HEAD";
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                if (long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength))
                {
                    result = ContentLength;
                }
            }

            return result;
        }

        public static long SplitFileSize(int tasksCount)
        {
            long fileSize = new long();
            return fileSize / tasksCount;
        }
    }
}
