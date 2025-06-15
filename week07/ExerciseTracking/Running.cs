using System;

public class Running : Activity
{
    private double _distance;//because in the runner we want know how many kilometers in what time

    public Running(DateTime date, int minutes, double distance) : base(minutes, date)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60; // km/h
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance; // min/km
    }
}