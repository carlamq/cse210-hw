using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent() => _points;
    public override bool IsComplete() => false;//goals are never complete
    public override string GetStringRepresentation()
    {
        return $"EternalGoal: {_shortName}, {_description}, {_points}";
    }
}