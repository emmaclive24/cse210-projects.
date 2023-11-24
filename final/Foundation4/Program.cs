using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities =  new List<Activity>();
        activities.Add(new RunningActivity("12 Jan 2021",6.7,30));
        activities.Add(new CyclingActivity("22 Feb 2015",9.6,30));
        activities.Add(new Swimming("27 Nov 2022",96,30));

        int index = 1;
        foreach(Activity activity in activities)
        {
            Console.WriteLine($"\nACTIVITY N°{index}:\n{activity.GetSummary()}");
            index++;
        }
        Console.WriteLine();    
    }
}