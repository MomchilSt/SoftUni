using System;

class Program
{
    static void Main()
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());
        int specialNum = int.Parse(Console.ReadLine());
        int controlNum = int.Parse(Console.ReadLine());

        

        for (int m1 = m; m1>=1; m1--)
        {

            for (int m2 = n; m2>=1; m2--)
            {

                for (int m3 = l; m3>=1; m3--)
                {
                    int num = m1 * 100 + m2 * 10 + m3;

                    if (num % 3 == 0)
                    {
                        specialNum += 5;
                    }
                    else if (num % 5 == 0)
                    {
                        specialNum -= 2;
                    }
                    else if (num % 2 == 0)
                    {
                        specialNum *= 2;
                    }
                     
                    if (specialNum >= controlNum)
                    {
                        Console.WriteLine("Yes! Control number was reached! Current special number is {0}.", specialNum);
                        return;
                    }
                }
            }
        }
        Console.WriteLine("No! {0} is the last reached special number.", specialNum);
    }
}
