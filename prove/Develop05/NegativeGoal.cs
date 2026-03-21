public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent() => -_points;

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[-] {_name} ({_description}) [Bad habit: -{_points} pts each occurrence]";
    }

    public override GoalData ToGoalData()
    {
        return new GoalData
        {
            Type        = "Negative",
            Name        = _name,
            Description = _description,
            Points      = _points
        };
    }
}
