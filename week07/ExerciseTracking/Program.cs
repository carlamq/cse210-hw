using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 1), 30, 5.0),
            new Running(new DateTime(2022, 11, 2), 25, 4.2),
            new Running(new DateTime(2022, 11, 3), 40, 7.0),
            new Cycling(new DateTime(2022, 11, 2), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 1), 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}