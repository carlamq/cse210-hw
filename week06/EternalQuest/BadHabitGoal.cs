using System;

public class BadHabitGoal : Goal
{
    private int _daysWithoutRelapse;
    private int _relapsePenalty;
    private int _dailyPoints;

    public BadHabitGoal(string name, string description, int points, int relapsePenalty, int dailyPoints)
        : base(name, description, points)
    {
        _daysWithoutRelapse = 0;
        _relapsePenalty = relapsePenalty;
        _dailyPoints = dailyPoints;
    }

    // Records a day without relapse, returns points for the day
    public override int RecordEvent()
    {
        Console.Write("Did you relapse today? (yes/no): ");
        string input = Console.ReadLine().Trim().ToLower();

        if (input == "yes")
        {
            _daysWithoutRelapse = 0;
            Console.WriteLine($"Sorry! You lose {_relapsePenalty} points.");
            return -_relapsePenalty;
        }
        else
        {
            _daysWithoutRelapse++;
            Console.WriteLine($"Well done! You have {_daysWithoutRelapse} days without relapse. You earn {_dailyPoints} points.");
            return _dailyPoints;
        }
    }

    public override bool IsComplete()
    {
        //can define a goal, for example, 30 days without relapse 
        //return _daysWithoutRelapse>= 30;
        return false; //for this case I will not define for easy testing
    }

    public override string GetDetailsString()
    {
        return $"[BadHabit] {_shortName} - {_description} (Days without relapse: {_daysWithoutRelapse})";
    }

    public override string GetStringRepresentation()
    {
        return $"BadHabitGoal: {_shortName}, {_description}, {_dailyPoints}, {_relapsePenalty}, {_daysWithoutRelapse}";
    }
}