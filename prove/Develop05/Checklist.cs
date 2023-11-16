using System;
public class Checklist : Goal
{
    private int _targetCount;
    private int _currentCount;
    private static int  _awardedPoints;
    private int _bonusPoints;
   // private static object description;
    //private static string name;
   // private int awardedPoints;
    

    public Checklist(string name, string description, int points, bool isComplete, int currentCount, int targetCount, int bonusPoints, object awardedPoints) : base()
    {
        _isComplete = false;
        _targetCount = 0;
        _currentCount = 0;
        _bonusPoints = 0;
        _name = name;
        _desc = description;
        _points = points;
        _targetCount = targetCount;
        _currentCount = currentCount;
        _awardedPoints = (int)awardedPoints;
    }

    public Checklist(string name, string description, int points, bool isComplete, int currentCount,int targetCount )
    {
    }

    public Checklist()
    {
    }

    public Checklist(string name, string description, int points, bool isComplete, int currentCount, int targetCount, int v) : this(name, description, points, isComplete, currentCount, targetCount)
    {
    }

    public void GoalBonus()
    {
        Console.WriteLine("You only have a few trials for this.");
        _targetCount  = int.Parse(Console.ReadLine());
        Console.Write("Enter the  number of points you wish to earn");
        _bonusPoints = int.Parse(Console.ReadLine());
    }

    public override void DisplayGoal(int goalNumber)
    {
        string checkBox = "[]";
        if (_isComplete)
        checkBox = "[x]";
        Console.WriteLine($"{goalNumber}. {checkBox} {_name} ({_desc})  {_currentCount}/{_targetCount}");
    }

     public override void RecordEvent()
       {
        _currentCount ++;
       if (_currentCount == _targetCount){
           _isComplete = true;
        }
}

        public override string DisplayGoalString()
    {
        string goal = $"ChecklistGoal|{_name}|{_desc}|{_points}|{_isComplete}|{_currentCount}/{_targetCount}|{_bonusPoints}";
        return goal;
    }



}
