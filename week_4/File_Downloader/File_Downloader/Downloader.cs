using ShellProgressBar;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace File_Downloader
{
    public static class Downloader
    {
        public static void DownloadFile(string fileUrl, int numberOfParallelDownloads = 0)
        {
            DownloadResult result = Download(fileUrl, numberOfParallelDownloads);

            Console.WriteLine($"Location: {result.FilePath}");
            Console.WriteLine($"Size: {result.Size}bytes");
            Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
            Console.WriteLine($"Parallel: {result.ParallelDownloads}");
        }

        private static long GetFileSize(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "HEAD";
            long responseLength;
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                responseLength = long.Parse(webResponse.Headers.Get("Content-Length"));
                return responseLength;
            }
        }

        private static DownloadResult Download(string fileUrl, int numberOfParallelDownloads)
        {
            Uri uri = new(fileUrl);
            string path = @"c:\temp\";
            string destinationFilePath = Path.Combine(path, uri.Segments.Last());
            DownloadResult result = new() { FilePath = destinationFilePath };
            if (numberOfParallelDownloads <= 0)
            {
                numberOfParallelDownloads = Environment.ProcessorCount;
            }

            long fileSize = GetFileSize(fileUrl);

            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            using FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Append);
            ConcurrentDictionary<int, String> tempFilesDictionary = new ConcurrentDictionary<int, String>();

            List<Range> readRanges = new List<Range>();
            for (int chunk = 0; chunk < numberOfParallelDownloads - 1; chunk++)
            {
                var range = new Range()
                {
                    Start = chunk * (fileSize / numberOfParallelDownloads),
                    End = ((chunk + 1) * (fileSize / numberOfParallelDownloads)) - 1
                };
                readRanges.Add(range);
            }
            readRanges.Add(new Range()
            {
                Start = readRanges.Any() ? readRanges.Last().End + 1 : 0,
                End = fileSize - 1
            });

            DateTime startTime = DateTime.Now;

            int index = 0;

            Enumerable.Range(1, readRanges.Count)
                .AsParallel()
                .ForAll(_ =>
                {
                    HttpWebRequest httpWebRequest = HttpWebRequest.Create(fileUrl) as HttpWebRequest;
                    httpWebRequest.Method = "GET";
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        string tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            Console.WriteLine("Thread {0} is performing the task...", Thread.CurrentThread.ManagedThreadId);
                            httpWebResponse.GetResponseStream().CopyTo(fileStream);
                            tempFilesDictionary.TryAdd((int)index, tempFilePath);
                        }
                    }
                    index++;
                });

            result.ParallelDownloads = index;
            result.TimeTaken = DateTime.Now.Subtract(startTime);
            result.Size = fileSize;

            foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
            {
                byte[] tempFileBytes = File.ReadAllBytes(tempFile.Value);
                destinationStream.Write(tempFileBytes, 0, tempFileBytes.Length);
                File.Delete(tempFile.Value);
            }
            return result;
        }
    }
}