using System;

class Program
{
    static void Main()
    {
        char capLetter = char.Parse(Console.ReadLine());
        char firstSmallLetter = char.Parse(Console.ReadLine());
        char secondSmallLetter = char.Parse(Console.ReadLine());
        char thirdSmallLetter = char.Parse(Console.ReadLine());
        int digit = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int big = 'A'; big <= capLetter; big++)
        {

            for (int first = 'a'; first <= firstSmallLetter; first++)
            {

                for (int second = 'a'; second <= secondSmallLetter; second++)
                {

                    for (int third = 'a'; third <= thirdSmallLetter; third++)
                    {

                        for (int m = 0; m <= digit; m++)
                        {
                            if (big == capLetter && first == firstSmallLetter && second == secondSmallLetter && third == thirdSmallLetter && m == digit)
                            {
                                break;
                            }
                            counter++;
                        }
                    }
                }
            }
        }
        Console.WriteLine(counter);
    }
}
