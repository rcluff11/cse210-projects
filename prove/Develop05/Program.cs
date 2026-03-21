/* My attempt at creativity with this was first to make it look fancy and cool
and second was I added a negative goal so something that tracks bad habits as well.
It mkaes it so once you do something that you probably should't you record that and
it will subtract points from your total. I idi want to menttion that I did use AI
to generate the odd charaters used to mak eit lopk nice, and the eternal quest box.*/
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║      ETERNAL QUEST  ✦        ║");
        Console.WriteLine("╚══════════════════════════════╝");

        GoalManager manager = new GoalManager();
        ShowMenu(manager);

        Console.WriteLine("\nFarewell, brave quester. Keep up the good work!");
    }

    private static void ShowMenu(GoalManager manager)
    {
        bool running = true;
        while (running)
        {
            manager.DisplayPlayerInfo();

            Console.WriteLine("\n  ── Menu ──────────────────────");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record an Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("\n  Choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice.Trim())
            {
                case "1":
                    CreateGoalMenu(manager);
                    break;
                case "2":
                    Console.WriteLine();
                    manager.ListGoalDetails();
                    break;
                case "3":
                    RecordEventMenu(manager);
                    break;
                case "4":
                    Console.Write("  Save filename: ");
                    string saveFile = (Console.ReadLine() ?? "goals.txt").Trim();
                    manager.SaveGoals(saveFile);
                    Console.WriteLine($"  ✓ Goals saved to '{saveFile}'.");
                    break;
                case "5":
                    Console.Write("  Load filename: ");
                    string loadFile = (Console.ReadLine() ?? "goals.txt").Trim();
                    if (File.Exists(loadFile))
                    {
                        manager.LoadGoals(loadFile);
                        Console.WriteLine($"  ✓ Goals loaded from '{loadFile}'.");
                    }
                    else
                    {
                        Console.WriteLine($"  ✗ File '{loadFile}' not found.");
                    }
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("  Invalid option — please enter 1–6.");
                    break;
            }
        }
    }

    private static void CreateGoalMenu(GoalManager manager)
    {
        Console.WriteLine("\n  Goal Types:");
        Console.WriteLine("  1. Simple Goal      (one-time completion)");
        Console.WriteLine("  2. Eternal Goal     (repeating, never finished)");
        Console.WriteLine("  3. Checklist Goal   (complete N times for a bonus)");
        Console.WriteLine("  4. Negative Goal    (bad habit — costs points)");
        Console.Write("  Choose type: ");

        string typeChoice = (Console.ReadLine() ?? "").Trim();

        Console.Write("  Goal name: ");
        string name = (Console.ReadLine() ?? "").Trim();

        Console.Write("  Short description: ");
        string description = (Console.ReadLine() ?? "").Trim();

        Console.Write("  Points per event: ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("  ✗ Invalid point value.");
            return;
        }

        switch (typeChoice)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;

            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("  How many times must this be completed? ");
                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("  ✗ Invalid target.");
                    return;
                }
                Console.Write("  Bonus points awarded on final completion: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("  ✗ Invalid bonus.");
                    return;
                }
                manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;

            case "4":
                manager.AddGoal(new NegativeGoal(name, description, points));
                break;

            default:
                Console.WriteLine("  ✗ Invalid type.");
                return;
        }

        Console.WriteLine($"  ✓ Goal '{name}' created!");
    }

    private static void RecordEventMenu(GoalManager manager)
    {
        Console.WriteLine();
        manager.ListGoalDetails();

        List<Goal> goals = manager.GetGoals();
        if (goals.Count == 0)
            return;

        Console.Write("\n  Which goal did you complete? (enter number): ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > goals.Count)
        {
            Console.WriteLine("  ✗ Invalid selection.");
            return;
        }

        int levelBefore = manager.GetLevel();
        int scoreBefore = manager.GetScore();
        int earned      = manager.RecordEvent(index - 1);

        if (earned > 0)
            Console.WriteLine($"\n  ✦ You earned {earned} points! Great work!");
        else if (earned < 0)
            Console.WriteLine($"\n  ✗ You lost {Math.Abs(earned)} points. Try to do better!");
        else
            Console.WriteLine("\n  (This goal is already complete or awarded no points.)");

        Goal completedGoal = goals[index - 1];
        if (completedGoal.IsComplete() && earned > 0)
            Console.WriteLine($"  🏆 Goal complete: '{completedGoal.GetName()}'! Excellent!");

        int scoreAfter = manager.GetScore();
        foreach (int milestone in new[] { 500, 1000, 5000, 10000 })
        {
            if (scoreBefore < milestone && scoreAfter >= milestone)
                Console.WriteLine($"  ★ Milestone reached: {milestone} total points!");
        }

        int levelAfter = manager.GetLevel();
        if (levelAfter > levelBefore)
            Console.WriteLine($"  *** LEVEL UP! Welcome to Level {levelAfter}! ***");
    }
}
