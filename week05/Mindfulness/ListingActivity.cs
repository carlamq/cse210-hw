using System;
using System.Collections.Generic;
public class ListingActivity: Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the things you are grateful for by listing them out.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Take a moment to reflect on the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(5);
        Console.WriteLine("\nNow, list as many items as you can related to the prompt. Press Enter after each item.");

        List<string> userList = new List<string>();//make a list to store the responses
        DateTime endTime = DateTime.Now.AddSeconds(_duration);//set the duration for the activity

        while (DateTime.Now < endTime)//while still have time continue
        {
            if (Console.KeyAvailable)//if the user press any key
            {
                string input = Console.ReadLine();//read the input from the user and save in the input variable
                if (string.IsNullOrWhiteSpace(input))//if the input is empty or whitespace, break the loop
                    break;
                userList.Add(input);//if hace some input, add it to the list
            }
        }
        Console.WriteLine($"\nYou listed {userList.Count} items!");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}