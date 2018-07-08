using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, decimal> paths = new Dictionary<string, decimal>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(';');
            string path = input[0];
            decimal size = decimal.Parse(input[1]);

            paths[path] = size;
        }
        
        string[] search = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        string searchExtension = search.First();
        string searchRoot = search.Last();

        paths = paths
            .OrderByDescending(s => s.Value)
            .ThenBy(x => x.Key.Split('\\').Last())
            .ToDictionary(p => p.Key, s => s.Value);

        bool hasMatches = false;
        foreach (var path in paths)
        {
            string file = path.Key.Split('\\').Last()
                .TrimStart(' ', '\t')
                .TrimEnd(' ', '\t');
            string extension = file.Split('.').Last();

            if (path.Key.StartsWith(searchRoot) && extension == searchExtension)
            {
                hasMatches = true;
                Console.WriteLine($"{file} - {path.Value} KB");
            }
        }

        if (!hasMatches)
        {
            Console.WriteLine("No");
        }
    }
}
