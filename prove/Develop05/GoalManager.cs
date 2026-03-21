
public class GoalManager
{
    private List<Goal> _goals;
    private int        _score;

    private const int PointsPerLevel = 1000;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public List<Goal> GetGoals() => _goals;

    public int GetScore() => _score;
    public int GetLevel() => (_score / PointsPerLevel) + 1;
    public int GetPointsToNextLevel() => PointsPerLevel - (_score % PointsPerLevel);
    public void DisplayPlayerInfo()
    {
        int level         = GetLevel();
        int toNext        = GetPointsToNextLevel();
        int progressWidth = 20;
        int filled        = progressWidth - (int)((toNext / (double)PointsPerLevel) * progressWidth);
        string bar        = "[" + new string('█', filled) + new string('░', progressWidth - filled) + "]";

        Console.WriteLine($"\n  ✦  Score : {_score} pts");
        Console.WriteLine($"  ✦  Level : {level}");
        Console.WriteLine($"  ✦  Next  : {bar} {toNext} pts to Level {level + 1}");
    }
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  (No goals created yet.)");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public int RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
            return 0;

        int earned = _goals[goalIndex].RecordEvent();
        _score += earned;   
        return earned;
    }
    public void SetData(int score, List<Goal> goals)
    {
        _score = score;
        _goals = goals;
    }

    public void SaveGoals(string filename)
    {
        GoalFileHandler handler = new GoalFileHandler();
        handler.Save(filename, _score, _goals);
    }

    public void LoadGoals(string filename)
    {
        GoalFileHandler handler = new GoalFileHandler();
        SaveData data  = handler.Load(filename);

        List<Goal> goals = new List<Goal>();
        foreach (GoalData gd in data.Goals)
        {
            Goal g = handler.CreateGoalFromData(gd);
            if (g != null)
                goals.Add(g);
        }

        SetData(data.Score, goals);
    }
}
