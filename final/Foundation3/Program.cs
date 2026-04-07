using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        events.Add(new Lecture("Introduction to Machine Learning", "April 10, 2026", "Dr. Sarah Chen", 120));
        events.Add(new Reception("Annual Tech Networking Night", "April 18, 2026", "rsvp@technight.com"));
        events.Add(new OutdoorGathering("Spring Campus Picnic", "April 25, 2026", "Sunny with light breeze, 72°F"));

        foreach (Event e in events)
        {
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();
        }
    }
}