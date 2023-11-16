public class Eternal : Goal
{
    public Eternal(): base()
    {
        _isComplete = false;
    }

    public Eternal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _desc = description;
        _points = points;
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {}

    public override string DisplayGoalString()
    {
        string goal = $"EternalGoal|{_name}|{_desc}|{_points}|{_isComplete}";
        return goal;
    }
}
