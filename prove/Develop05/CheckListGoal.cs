using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class ChecklistGoal : Activity
{
    public ChecklistGoal(string name, int targetValue, int bonusPoints,DateTime deadline) 
    :base(name, GoalType.Checklist, targetValue, deadline, bonusPoints) 
    { 

    }

    public override void UpdateProgress(int value)
    {
        CurrentValue += value;

        if (CurrentValue >= TargetValue)
        {
            Completed = true;
            CurrentValue = TargetValue; // Cap the current value at the target value
        }
    }
}
