using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)//only record event if target is not yet reached
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                return _points + _bonus; //return points plus bonus when target is reached
            }
            return _points; //return points for each event recorded until target is reached
        }
        return 0; // No points if target is already reached

    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailsString()//for call IsComplete() method to check if the goal is complete
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} - {_description} (Points: {_points}, Completed: {_amountCompleted}/{_target}, Bonus: {_bonus})";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal: {_shortName}, {_description}, {_points}, {_amountCompleted}, {_target}, {_bonus}";
    }
}