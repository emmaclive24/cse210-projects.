public abstract class Goal
{
    protected string _name;
    protected string _desc;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _desc = description;
        _points = points;
        _isComplete = false;
    }

    public Goal()
    {
        _name = "";
        _desc = "";
        _points = 0;
        _isComplete = false;
    }

    public void GoalName()
    {
        Console.WriteLine("Please enter a title for your goal:");
        _name = Console.ReadLine();
    }

    public void GoalDesc()
    {
        Console.WriteLine("Describe what you want to accomplish:");
        _desc = Console.ReadLine();
    }

    public void GoalPoints()
    {
        Console.WriteLine("How many points is this goal worth?:");
        _points = int.Parse(Console.ReadLine());
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual void RecordEvent()
    {
        _isComplete = true;
    }

    public virtual bool Iscomplete()
    {
        return _isComplete;
    }

    public virtual void DisplayGoal (int goalNumber)
    {
        Console.WriteLine($"{goalNumber}. {_name} ({_desc})");
    }

    public virtual void DisplayGoalSimple(int goalNumber)
    {
        Console.WriteLine($"{goalNumber}. {_name}");
    }

    public virtual string DisplayGoalString()
    {
        string goal = $"{_name}|{_desc}| {_points}|{ _isComplete}";
        return goal;
    }
}