using System;
using System.Linq;
using System.Text.RegularExpressions;

public class WormIpsum
{
    public static void Main()
    {
        Regex sentenceReg = new Regex(@"^[A-Z][^\.]*\.$");
        Regex wordsReg = new Regex(@"[^\s,\.]+");

        string input = Console.ReadLine();
        while (!input.Equals("Worm Ipsum"))
        {
            Match sentenceMatch = sentenceReg.Match(input);
            if (sentenceMatch.Success)
            {
                MatchCollection wordsMatches = wordsReg.Matches(input);
                foreach (Match match in wordsMatches)
                {
                    string word = match.Value;
                    if (word.Length != word.Distinct().Count())
                    {
                        char symb = word.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                        string newWord = string.Concat(Enumerable.Repeat(symb, word.Length));
                        input = Regex.Replace(input, word, newWord);
                    }
                }

                Console.WriteLine(input);
            }

            input = Console.ReadLine();
        }
    }
}