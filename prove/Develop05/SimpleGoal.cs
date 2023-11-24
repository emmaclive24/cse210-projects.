using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class SimpleGoal : Activity
{
    public SimpleGoal(string name, int targetValue, DateTime deadline) : base(name, GoalType.Simple, targetValue, deadline) { }

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
