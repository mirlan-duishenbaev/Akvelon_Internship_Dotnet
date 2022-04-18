using Async_Task;

public class Programm
{
    public static void Main()
    {
        string url = @"https://images.wallpaperscraft.ru/image/single/sakura_lepestki_tsvety_275559_3840x2400.jpg";
        string fileName = "sakura.jpeg";
        Downloader.RunDownloadImage(url, fileName);
    }
}