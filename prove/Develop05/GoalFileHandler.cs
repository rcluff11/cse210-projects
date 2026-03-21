public class GoalFileHandler
{    public void Save(string filename, int score, List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);

            foreach (Goal goal in goals)
            {
                GoalData d = goal.ToGoalData();
                string safeName = d.Name.Replace(",", ";");
                string safeDesc = d.Description.Replace(",", ";");

                writer.WriteLine($"{d.Type},{safeName},{safeDesc},{d.Points}," +
                                 $"{d.IsComplete},{d.AmountCompleted},{d.TargetAmount},{d.Bonus}");
            }
        }
    }
    public SaveData Load(string filename)
    {
        SaveData saveData = new SaveData();

        string[] lines = File.ReadAllLines(filename);
        saveData.Score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] parts = lines[i].Split(',');

            GoalData data = new GoalData
            {
                Type            = parts[0],
                Name            = parts[1],
                Description     = parts[2],
                Points          = int.Parse(parts[3]),
                IsComplete      = bool.Parse(parts[4]),
                AmountCompleted = int.Parse(parts[5]),
                TargetAmount    = int.Parse(parts[6]),
                Bonus           = int.Parse(parts[7])
            };

            saveData.Goals.Add(data);
        }

        return saveData;
    }
    public Goal CreateGoalFromData(GoalData data)
    {
        return data.Type switch
        {
            "Simple"    => new SimpleGoal(data.Name, data.Description, data.Points, data.IsComplete),
            "Eternal"   => new EternalGoal(data.Name, data.Description, data.Points),
            "Checklist" => new ChecklistGoal(data.Name, data.Description, data.Points,
                                             data.TargetAmount, data.Bonus, data.AmountCompleted),
            "Negative"  => new NegativeGoal(data.Name, data.Description, data.Points),
            _           => null
        };
    }
}
