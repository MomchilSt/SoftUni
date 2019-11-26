using System;

namespace OldestFamilyMember
{
    class StartUp
    {
        static void Main()
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine("{0} {1}", oldestPerson.Name, oldestPerson.Age);
        }
    }
}
