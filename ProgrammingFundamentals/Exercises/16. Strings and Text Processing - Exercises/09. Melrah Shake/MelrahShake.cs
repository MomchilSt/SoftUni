using System;

class MelrahShake
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = Console.ReadLine();

        while (true)
        {
            int firstIndex = text.IndexOf(pattern);
            int lastIndex = text.LastIndexOf(pattern);

            if (firstIndex >= 0 && lastIndex >= 0 && pattern != "")
            {
                Console.WriteLine("Shaked it.");

                firstIndex = text.IndexOf(pattern);
                text = text.Remove(firstIndex, pattern.Length);

                lastIndex = text.LastIndexOf(pattern);
                text = text.Remove(lastIndex, pattern.Length);

                if (pattern.Length > 0)
                {
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
            }
            else
            {
                Console.WriteLine("No shake.");
                break;
            }
        }

        Console.WriteLine(text);
    }
}
