using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class EternalGoal : Activity
{
   public EternalGoal(string name, int targetValue, DateTime deadline) : base(name, GoalType.Eternal, targetValue, DateTime.MaxValue) { }

    public override void UpdateProgress(int value)
    {
        CurrentValue += value;
        TimesCompleted++; // Increment times completed each time it's recorded
    }
}
