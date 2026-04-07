using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("April 7, 2026", 30, 3.2));
        activities.Add(new Cycling("April 8, 2026", 45, 18.5));
        activities.Add(new Swimming("April 9, 2026", 40, 30));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}