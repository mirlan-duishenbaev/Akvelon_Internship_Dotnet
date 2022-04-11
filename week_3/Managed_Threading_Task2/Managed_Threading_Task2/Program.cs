using Managed_Threading_Task2;
public class Programm
{
    static void Main(string[] args)
    {
        Thread t1, t2, t3;
        string url = "https://jsonplaceholder.typicode.com/photos";
        var list = Image.CreateImageList(url);

        Random random1 = new Random();
        Random random2 = new Random();
        Random random3 = new Random();

        for (int i = 0; i < 10; i++)
        {
            int index1 = random1.Next(list.Count);
            int index2 = random1.Next(list.Count);
            int index3 = random1.Next(list.Count);
            t1 = new Thread(() => Image.DownloadImage(list[index1].ThumbnailUrl, list[index1].Id));
            t1.Start();
            t2 = new Thread(() => Image.DownloadImage(list[index2].ThumbnailUrl, list[index2].Id));
            t2.Start();
            t3 = new Thread(() => Image.DownloadImage(list[index3].ThumbnailUrl, list[index3].Id));
            t3.Start();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);
        }
    }
}





