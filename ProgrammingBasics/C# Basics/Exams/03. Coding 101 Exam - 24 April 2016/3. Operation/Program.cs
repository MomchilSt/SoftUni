using System;

namespace _3.Operation
{
    class Program
    {
        static void Main()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string operat = Console.ReadLine();

            switch (operat)
            {
                case "+":
                    int sum = n1 + n2;
                    if (sum % 2 == 0)
                        Console.WriteLine($"{n1} {operat} {n2} = {sum} - even");
                    else
                        Console.WriteLine($"{n1} {operat} {n2} = {sum} - odd");
                    break;
                case "-":
                    int diff = n1 - n2;
                    if (diff % 2 == 0)
                        Console.WriteLine($"{n1} {operat} {n2} = {diff} - even");
                    else
                        Console.WriteLine($"{n1} {operat} {n2} = {diff} - odd");
                    break;
                case "*":
                    int multip = n1 * n2;
                    if (multip % 2 == 0)
                        Console.WriteLine($"{n1} {operat} {n2} = {multip} - even");
                    else
                        Console.WriteLine($"{n1} {operat} {n2} = {multip} - odd");
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    double division = (double)n1 / n2;
                    if (division % 2 == 0)
                        Console.WriteLine($"{n1} {operat} {n2} = {division:f2}");
                    else
                        Console.WriteLine($"{n1} {operat} {n2} = {division:f2}");
                    break;
                case "%":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    int rem = n1 % n2;
                    if (rem % 2 == 0)
                        Console.WriteLine($"{n1} {operat} {n2} = {rem}");
                    else
                        Console.WriteLine($"{n1} {operat} {n2} = {rem}");
                    break;
            }
        }
    }
}
