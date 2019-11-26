using System;

class MetricConverter
{
    static void Main(string[] args)
    {
        var number = double.Parse(Console.ReadLine());
        var input = Console.ReadLine().ToLower();
        var output = Console.ReadLine().ToLower();
 
        var mm = 1000.0;
        var cm = 100.0;
        var mi = 0.000621371192;
        var inch = 39.3700787;
        var km = 0.001;
        var ft = 3.2808399;
        var yd = 1.0936133;
        var m = 1.0;
 
             if (input == "mm") { number /= mm; }
        else if (input == "cm") { number /= cm; }
        else if (input == "mi") { number /= mi; }
        else if (input == "in") { number /= inch; }
        else if (input == "km") { number /= km; }
        else if (input == "ft") { number /= ft; }
        else if (input == "yd") { number /= yd; }
        else if (input == "m") { number /= m; }
        else { Console.WriteLine("Wrong Input"); }
 
             if (output == "mm") { number *= mm; }
        else if (output == "cm") { number *= cm; }
        else if (output == "mi") { number *= mi; }
        else if (output == "in") { number *= inch; }
        else if (output == "km") { number *= km; }
        else if (output == "ft") { number *= ft; }
        else if (output == "yd") { number *= yd; }
        else if (output == "m") { number *= m; }
        else { Console.WriteLine("Wrong Output"); }
        
        Console.WriteLine("{0} {1}", number, output);
    }
}