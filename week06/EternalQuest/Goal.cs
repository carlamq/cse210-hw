using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();//is abstract because each class sett its own implementation
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} - {_description} (Points: {_points})";
    }
    public abstract string GetStringRepresentation();
}