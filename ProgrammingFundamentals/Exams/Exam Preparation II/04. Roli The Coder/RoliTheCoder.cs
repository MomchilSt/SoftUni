using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Event
{
    public string Name { get; set; }
    public List<string> Participants { get; set; }
}

class RoliTheCoder
{
    static void Main()
    {
        Dictionary<string, Event> events = new Dictionary<string, Event>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Time for Code")
            {
                break;
            }

            string[] data = input
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (!data[1].Contains('#'))
            {
                continue;
            }

            string id = data[0];
            string eventName = data[1].Substring(1);
            List<string> participants = string.Join(" ", data.Skip(2))
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var person in participants)
            {
                if (!person.Contains('@'))
                {
                    continue;
                }
            }

            if (events.ContainsKey(id))
            {
                if (events[id].Name == eventName)
                {
                    events[id].Participants = events[id].Participants
                        .Concat(participants)
                        .ToList();
                }
                else
                {
                    continue;
                }
            }
            else
            {
                Event @event = new Event()
                {
                    Name = eventName,
                    Participants = participants
                };

                events[id] = @event;
            }
        }

        foreach (Event evnt in events.Values)
        {
            evnt.Participants = evnt.Participants
                .OrderBy(x => x)
                .Distinct()
                .ToList();
        }

        events = events
            .OrderByDescending(e => e.Value.Participants.Count)
            .ThenBy(e => e.Value.Name)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (Event evnt in events.Values)
        {
            Console.WriteLine($"{evnt.Name} - {evnt.Participants.Count}");

            foreach (string person in evnt.Participants)
            {
                Console.WriteLine(person);
            }
        }
    }
}
