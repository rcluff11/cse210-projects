using System;
using System.IO;
using System.Threading;

/*My attempt at creativity is that I've written in a function called
SaveToLog that logs the activity that you did when you did it and 
for how long you did it for.*/ 

class Program
{
    static string logFile = "activity_log.txt";

    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            ShowMenu();
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                choice = 0;
            }

            RunChoice(choice);
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflection activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.WriteLine();
    }

    static void RunChoice(int choice)
    {
        Activity activity = null;

        if (choice == 1)
        {
            activity = new BreathingActivity();
        }
        else if (choice == 2)
        {
            activity = new ReflectionActivity();
        }
        else if (choice == 3)
        {
            activity = new ListingActivity();
        }
        else if (choice == 4)
        {
            Console.WriteLine("Goodbye!");
        }
        else
        {
            Console.WriteLine("That's not a valid option. Try again.");
            Thread.Sleep(1500);
            return;
        }

        if (activity != null)
        {
            activity.Run();
            SaveToLog(activity);
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }

    static void SaveToLog(Activity activity)
    {
        string activityType = activity.GetType().Name;
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"{timestamp} - Completed: {activityType}";

        try
        {
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
            Console.WriteLine($"\n(Activity saved to log: {logFile})");
        }
        catch (Exception e)
        {
            Console.WriteLine("Couldn't save to log file: " + e.Message);
        }
    }
}