using System;
using System.IO;
using System.Linq;

public class GoalFiles
{
    private const string V = "|";
    private System.Collections.Generic.List<Goal> _goals = new System.Collections.Generic.List<Goal>();
    private int _points = 0;

    public GoalFiles()
    {
        _points = 0;
        _goals = new System.Collections.Generic.List<Goal>();
    }

    public void Save(System.Collections.Generic.List<Goal> goals, int points)
    {
        Console.WriteLine("Name the file!");
        string fileName = Console.ReadLine();
        using (StreamWriter file = new StreamWriter(fileName))
        {
            file.WriteLine(points);
            foreach (Goal line in goals)
            {
                file.WriteLine(line.DisplayGoalString());
            }
        }
    }

    public void Load()
    {
        Console.WriteLine("Enter the name of the file:");
        string fileName = Console.ReadLine();
        String line;
        try
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                line = file.ReadLine();
                _points = int.Parse(line);
                line = file.ReadLine();
                while (line != null)
                {
                    //string[] goalLines = line.Split(V);
                    string[] goalLines = line.Split('V');
                    char[][] charLines = goalLines.Select(s => s.ToCharArray()).ToArray();

                    string goalType = goalLines[0];
                    if(goalType == "SimpleGoal")
                    {
                        Simple goal = new Simple(goalLines[1], goalLines[2],int.Parse(goalLines[3]), bool.Parse(goalLines[4]));
                        _goals.Add(goal);
                    }
                    if(goalType == "EternalGoal")
                    {
                        Eternal goal = new Eternal(goalLines[1], goalLines[2],int.Parse(goalLines[3]), bool.Parse(goalLines[4]));
                        _goals.Add(goal);
                    }
                     if(goalType == "ChecklistGoal")
                     {
                        Checklist goal = new Checklist(goalLines[1], goalLines[2],int.Parse(goalLines[3]),bool.Parse(goalLines[4]), int.Parse(goalLines[5]),int.Parse(goalLines[6]),int.Parse(goalLines[7]));
                        _goals.Add(goal);
                    }
                    line = file.ReadLine();
                };
            }

        }
        catch (Exception error)
        {
            Console.WriteLine("Exception:" + error.Message);
        }
    }
    public System.Collections.Generic.List<Goal> GetGoals()
    {
        return _goals;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void GetSavedGoal(System.Collections.Generic.List<Goal> goals){
        Console.WriteLine("The goals are: ");
                int x = 0;
                foreach(Goal goal in goals)
                {
                    x++;
                    goal.DisplayGoal(x);
                }
                Console.Write("Enter your saved goal.");
                int input = int.Parse(Console.ReadLine());
                Goal selectedGoal = goals[input-1];
                selectedGoal.RecordEvent();
                _points = GetPoints() + selectedGoal.GetPoints();
                Console.WriteLine($" You have been awarded the folowing {selectedGoal.GetPoints()}");
                Console.WriteLine($"Current score is{_points}");
                Console.WriteLine("");
    }

    internal object RecordEvent(System.Collections.Generic.List<Goal> goals)
    {
        throw new NotImplementedException();
    }
}