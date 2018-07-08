using System;
using System.Collections.Generic;
using System.Linq;

class Trainlands
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> trains = new Dictionary<string, Dictionary<string, int>>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "It's Training Men!") { break; }

            List<string> splitedInput = new List<string>();
            if (input.Contains(" = "))
            {
                splitedInput = input.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string trainName = splitedInput[0];
                string otherTrainName = splitedInput[1];

                if (!trains.ContainsKey(trainName))
                {
                    trains[trainName] = new Dictionary<string, int>();
                }

                Dictionary<string, int> otherTrainWagons = new Dictionary<string, int>(trains[otherTrainName]);
                trains[trainName] = new Dictionary<string, int>(otherTrainWagons);
            }
            else
            {
                splitedInput = input.Split(new string[] { " -> ", " : " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (splitedInput.Count == 3)
                {
                    string trainName = splitedInput[0];
                    string wagonName = splitedInput[1];
                    int wagonPower = int.Parse(splitedInput[2]);

                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, int>();
                    }

                    trains[trainName].Add(wagonName, wagonPower);
                }
                else if (splitedInput.Count == 2)
                {
                    string trainName = splitedInput[0];
                    string otherTrainName = splitedInput[1];

                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, int>();
                    }

                    foreach (var item in trains[otherTrainName])
                    {
                        trains[trainName].Add(item.Key, item.Value);
                    }

                    trains.Remove(otherTrainName);
                }
            }
        }

        trains = trains
            .OrderByDescending(x => x.Value.Values.Sum())
            .ThenBy(x => x.Value.Values.Count())
            .ToDictionary(x => x.Key, x => x.Value);

        for (int i = 0; i < trains.Count; i++)
        {
            var item = trains.ElementAt(i);
            var wagonName = item.Key;

            trains[wagonName] = trains[wagonName]
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        foreach (var train in trains)
        {
            Console.WriteLine($"Train: {train.Key}");

            foreach (var wagon in train.Value)
            {
                Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
            }
        }
    }
}
