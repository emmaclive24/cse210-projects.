using System;

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalFiles file = new GoalFiles();
        List<Goal> goals = new List<Goal>();
        int points = 0;
        int quit = 0;
        int choice = 0;
        while (quit != 6)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Eternal Goals Game");
            Console.WriteLine($"You have {points} points.");
            Console.WriteLine(" ");
            Console.WriteLine("The following is the Menu");
            Console.WriteLine("Please select an option:");
            Console.WriteLine(" 1. Create a Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record the Event:");
            Console.WriteLine(" 6. Quit");
            
            quit = int.Parse(Console.ReadLine());
            Console.Clear();

            if (quit == 1)
            {        
                Console.WriteLine("Select a goal from the following list:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal ");          
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Simple simple = new Simple();
                    simple.GoalName();
                    simple.GoalDesc();
                    simple.GoalPoints();
                    goals.Add(simple);
                }

                if (choice == 2)
                {
                  Eternal eternal = new Eternal();
                    eternal.GoalName();
                    eternal.GoalDesc();
                    eternal.GoalPoints();
                    goals.Add(eternal);  
                }
                if (choice == 3)
                {
                    Checklist checklist = new Checklist();
                    checklist.GoalName();
                    checklist.GoalDesc();
                    checklist.GoalPoints();
                    checklist.GoalBonus(); 
                    goals.Add(checklist);
                }
            }

            else if (quit == 2)
            {
                if (goals.Count == 0)
                {
                    Console.WriteLine("Invalid. Please create goals!");
                }
                else
                {
                    int x = 0;
                    foreach (Goal goal in goals)
                    {   
                        x++;
                        goal.DisplayGoal(x);   
                    }  
                }  
            }
            else if (quit == 3)
            {
                file.Save(goals, points);
            }

            else if (quit == 4)
            {
                file.Load();
                goals = file.GetGoals();
                points = file.GetPoints();
            }

            else if (quit == 5)
            {
                object value = file.RecordEvent(goals);
                points = file.GetPoints();
            }

            else
            {
              Console.WriteLine("Thank you for setting worthwhile goals today! next time!");
              break;  
            }
            Console.Clear();
        }
    }
}
