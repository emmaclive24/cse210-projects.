using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();
        goalManager.LoadGoals(); // Load existing goals

        while (true)
        {
            Console.WriteLine("Goal Tracker Menu:");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save and Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.DisplayGoals();
                    break;

                case "2":
                    goalManager.AddGoal();
                    break;

                case "3":
                    goalManager.RecordEvent();
                    break;

                case "4":
                    Console.WriteLine($"Your Current Score: {goalManager.GetTotalScore()}");
                    break;

                case "5":
                    goalManager.SaveGoals(); 
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

abstract class Activity
{
    public string Name { get; set; }
    public GoalType Type { get; set; }
    public int TargetValue { get; set; }
    public int CurrentValue { get; set; }
    public bool Completed { get; set; }
    public int BonusPoints { get; set; }
    public int TimesCompleted { get; set; }

    public Activity(string name, GoalType type, int targetValue, DateTime deadline, int bonusPoints = 0)
{
    Name = name;
    Type = type;
    TargetValue = targetValue;
    BonusPoints = bonusPoints;
    Deadline = deadline;
}


    public DateTime Deadline { get; set; }

    


    public abstract void UpdateProgress(int value);
}





enum GoalType
{
    Simple,
    Eternal,
    Checklist
}
