using Managed_Threading_Task1;

public class Programm
{
    static void Main(string[] args)
    {
        Thread dancer1, dancer2, dancer3;
        int dance = new();
        int count = 0;

        Console.WriteLine("\nDJ starts the music on!");

        Thread music = new Thread(() =>
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                var index = rnd.Next(1, 4);
                Console.WriteLine("\nTrack #{0}", i + 1);
                Console.WriteLine($"{(Managed_Threading_Task1.enums.Music)index} is playing!");
                count = i;
                dance = index;
                Thread.Sleep(5000);
            }
        });

        music.Start();

        while (music.IsAlive)
        {
            Thread.Sleep(1000);
            dancer1 = new Thread(() => DanceFloor.AllAreDancing(dance))
            {
                Name = "John"
            };
            dancer2 = new Thread(() => DanceFloor.AllAreDancing(dance))
            {
                Name = "Anna"
            };
            dancer3 = new Thread(() => DanceFloor.AllAreDancing(dance))
            {
                Name = "Brad"
            };
            dancer1.Start();
            dancer2.Start();
            dancer3.Start();
            Thread.Sleep(4000);
        }

        if (count == 19)
        {
            music.Join();
            Console.WriteLine("\nThe disco is over!");
        }
    }
}















