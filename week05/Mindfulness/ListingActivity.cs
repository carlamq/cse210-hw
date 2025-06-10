using System;
using System.Collections.Generic;
public class ListingActivity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(int count, List<string> prompts)
    {
        _count = count;
        _prompts = prompts;
    }
    public void Run()
    {
        Console.WriteLine("Running listing activity...");
    }
    public string GetRandomPrompt()
    {
        return "This is a random prompt.";
    }
    public List<string> GetListFromUser()
    {
        Console.WriteLine("Getting list from user...");
        return new List<string>();
    }
}