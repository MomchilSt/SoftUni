using System;

namespace _4.SoftUni_Camp
{
    class Program
    {
        static void Main()
        {
            int groups = int.Parse(Console.ReadLine());

            double peopleCar = 0;
            double peopleVan = 0;
            double peopleMinibus = 0;
            double peopleBus = 0;
            double peopleTrain = 0;
            double allPeople = 0;

            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());

                if (people >= 41)
                    peopleTrain += people;
                else if (people >= 26)
                    peopleBus += people;
                else if (people >= 13)
                    peopleMinibus += people;
                else if (people >= 6)
                    peopleVan += people;
                else
                    peopleCar += people;

                allPeople += people;
            }

            peopleCar = peopleCar / allPeople * 100;
            peopleVan = peopleVan / allPeople * 100;
            peopleMinibus = peopleMinibus / allPeople * 100;
            peopleBus = peopleBus / allPeople * 100;
            peopleTrain = peopleTrain / allPeople * 100;

            Console.WriteLine($"{peopleCar:f2}%");
            Console.WriteLine($"{peopleVan:f2}%");
            Console.WriteLine($"{peopleMinibus:f2}%");
            Console.WriteLine($"{peopleBus:f2}%");
            Console.WriteLine($"{peopleTrain:f2}%");
        }
    }
}
