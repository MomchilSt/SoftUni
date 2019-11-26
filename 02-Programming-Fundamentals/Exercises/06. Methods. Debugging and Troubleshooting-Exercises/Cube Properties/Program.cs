using System;

class P10CubeProperties
{
    static void Main(string[] args)
    {
        double n = double.Parse(Console.ReadLine());
        string calculate = Console.ReadLine().ToLower();

        if (calculate == "face")
        {
            PrintFaceOfCube(n);
        }
        else if (calculate == "space")
        {
            PrintSpaceOfCube(n);
        }
        else if (calculate == "volume")
        {
            PrintVolumeOfCube(n);
        }
        else
        {
            PrintAreaOfCube(n);
        }
    }

    static void PrintVolumeOfCube(double n)
    {
        double result = n * n * n;
        Console.WriteLine("{0:f2}", result);
    }

    static void PrintAreaOfCube(double n)
    {
        double result = 6 * (n * n);
        Console.WriteLine("{0:f2}", result);
    }

    static void PrintFaceOfCube(double n)
    {
        double result = Math.Sqrt(2 * (n * n));
        Console.WriteLine("{0:f2}", result);
    }

    static void PrintSpaceOfCube(double n)
    {
        double result = Math.Sqrt(3 * (n * n));
        Console.WriteLine("{0:f2}", result);
    }
}
