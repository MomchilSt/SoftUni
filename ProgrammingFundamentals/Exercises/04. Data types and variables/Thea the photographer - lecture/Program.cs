using System;

class Program
{
    static void Main()
    {
        int picturesTaken = int.Parse(Console.ReadLine());
        int filteringSeconds = int.Parse(Console.ReadLine());
        int percentGood = int.Parse(Console.ReadLine());
        int uploadTime = int.Parse(Console.ReadLine());

        int filteredPics = picturesTaken / percentGood;
        int totalFiltering = picturesTaken * filteringSeconds;
        int totalTime = totalFiltering + (filteredPics * uploadTime);

        int seconds = totalTime % 60;

        totalTime = (totalTime - (totalTime % 60)) / 60;

        int minutes = totalTime % 60;

        totalTime = (totalTime - (totalTime % 60)) / 60;

        int hours = totalTime % 24;

        totalTime = (totalTime - (totalTime % 24)) / 24;

        Console.WriteLine($"{totalTime}:{hours:d2}:{minutes:d2}:{seconds:d2}");
    }
}
