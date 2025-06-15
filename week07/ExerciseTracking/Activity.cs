using System;

public abstract class Activity
{
    protected int _minutes;
    protected DateTime _date;

    public Activity(int minutes, DateTime date)
    {
        _minutes = minutes;
        _date = date;
    }
    public DateTime GetDate()
    {
        return _date;
    }
    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract method to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min): " +//this.GetType().Name gets the name of the derived class
               $"Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}