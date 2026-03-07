using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _rand;

    public ListingActivity() : base("Listing",
    "this activity will help you reflect on the good things in your life\n by having oyu list as many things as you can in a certain area.")
    {
        _rand = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    private string GetRandomPrompt()
    {
        return _prompts[_rand.Next(_prompts.Count)];
    }

    public override void Run()
    {
        Start();

        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("You have a few seconds to think about it...");
        ShowCountdown(5);

        Console.WriteLine("Start listing items (press Enter after each one):");

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < _durationSeconds)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (item != null && item.Trim() != "")
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");

        End();
    }
}