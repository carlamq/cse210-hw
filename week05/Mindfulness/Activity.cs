using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} activity.");
        Console.WriteLine(_description + "\n");
        Console.Write("How much time do you want to spend on this activity? (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWELL DONE!");
        Console.WriteLine($"You have completed the {_name} activity.");
        Console.WriteLine("Thank you for participating!");
        Console.WriteLine("You will now return to the main menu in 3 seconds.");
        ShowCountdown(3);
    }
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };//array for spinning animation
        for (int i = 0; i < seconds * 4; i++)//repeats 4 times for each second
        {
            Console.Write(spinner[i % 4]);//prints the spinner character in order
            System.Threading.Thread.Sleep(300);//waits for 300 milliseconds
            Console.Write("\b");//removes the last character printed to replace it with the next one
        }
    }
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{i}...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}