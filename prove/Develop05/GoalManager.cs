using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

class GoalManager
{
    private List<Activity> activities = new List<Activity>();

    public void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");

        foreach (var activity in activities)
        {
            string status = activity.Completed ? "[X]" : "[ ]";

            if (activity.Type == GoalType.Checklist)
            {
                Console.WriteLine($"{status} {activity.Name} (Completed {activity.TimesCompleted}/{activity.TargetValue} times)");
            }
            else
            {
                Console.WriteLine($"{status} {activity.Name} ({activity.CurrentValue}/{activity.TargetValue})");
            }
        }

        Console.WriteLine();
    }

     public void AddGoal()
    {
        Console.WriteLine("\nAdd Goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string choice = Console.ReadLine();

        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Target Value: ");
        int targetValue = int.Parse(Console.ReadLine());

        Console.Write("Enter Deadline (yyyy-MM-dd): ");
        DateTime deadline = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);


        switch (choice)
        {
            case "1":
                activities.Add(new SimpleGoal(name, targetValue, deadline));
                break;

            case "2":
                activities.Add(new EternalGoal(name, targetValue, deadline));
                break;

            case "3":
                Console.Write("Enter Bonus Points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                activities.Add(new ChecklistGoal(name, targetValue, bonusPoints, deadline));
                break;

            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }

        Console.WriteLine("Goal Added!\n");
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nRecord Event:");
        Console.Write("Enter the name of the goal: ");
        string goalName = Console.ReadLine();

        Activity activity = activities.FirstOrDefault(a => a.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));

        if (activity != null)
        {
            Console.Write("Enter the value achieved: ");
            int value = int.Parse(Console.ReadLine());

            activity.UpdateProgress(value);

            Console.WriteLine("Event Recorded!\n");
        }
        else
        {
            Console.WriteLine("Goal not found. Event not recorded.\n");
        }
    }

    public int GetTotalScore()
    {
        return activities.Sum(activity => activity.Completed ? activity.BonusPoints + activity.CurrentValue : 0);
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var activity in activities)
            {
                writer.WriteLine($"{activity.Name},{activity.Type},{activity.TargetValue},{activity.BonusPoints},{activity.Completed},{activity.CurrentValue},{activity.TimesCompleted}");
            }
        }
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            activities.Clear();

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] values = reader.ReadLine().Split(',');

                    GoalType type = (GoalType)Enum.Parse(typeof(GoalType), values[1]);
                    Activity activity = null;

                    switch (type)
{   
    case GoalType.Simple:
        DateTime deadlineSimple = DateTime.ParseExact(values[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
        activity = new SimpleGoal(values[0], int.Parse(values[2]), deadlineSimple);
        break;

    case GoalType.Eternal:
        DateTime deadlineEternal = DateTime.ParseExact(values[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
        activity = new EternalGoal(values[0], int.Parse(values[2]), deadlineEternal);
        break;

    case GoalType.Checklist:
        DateTime deadlineChecklist = DateTime.ParseExact(values[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
        activity = new ChecklistGoal(values[0], int.Parse(values[2]), int.Parse(values[3]), deadlineChecklist);
        break;
}


                    if (activity != null)
                    {
                        activity.Completed = bool.Parse(values[4]);
                        activity.CurrentValue = int.Parse(values[5]);
                        activity.TimesCompleted = int.Parse(values[6]);

                        activities.Add(activity);
                    }
                }
            }
        }
    }
}