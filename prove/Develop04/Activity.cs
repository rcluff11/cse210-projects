using System;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcomne to the {_name} Activity!\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _durationSeconds = GetDuration();
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name} Acvtivity.");
        ShowSpinner(3);
    }

    public virtual void Run() { }

    protected int GetDuration()
    {
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid number of seconds: ");
        }
        return duration;
    }

    protected void ShowSpinner(int seconds)
{
    string[] spinner = { "|", "/", "-", "\\" };
    int totalTicks = seconds * 5;
    for (int i = 0; i < totalTicks; i++)
    {
        Console.Write(spinner[i % spinner.Length]);
        Thread.Sleep(200);
        Console.Write("\b \b");
    }
}

    protected void ShowCountdown(int seconds)
    {
        for(int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i + " ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }
}