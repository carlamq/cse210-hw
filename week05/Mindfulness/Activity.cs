using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity.");
        Console.WriteLine(_description);
        Console.WriteLine($"This activity will last for {_duration} seconds.");
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Ending {_name} activity.");
        Console.WriteLine("Thank you for participating!");
        Console.WriteLine($"You completed the activity in {_duration} seconds.");
    }
    public void ShowSpinner(int seconds)
    {

    }
    public void ShowCountdown(int seconds)
    {
      
    }
}