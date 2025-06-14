using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you felt proud of yourself.",
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
       "Why was this experience meaningful to you?",
       "Have you ever done anything like this before?",
       "How did you get started?",
       "How did you feel when it was complete?",
       "What made this time different than other times when you were not as successful?",
       "What is your favorite thing about this experience?",
       "What could you learn from this experience that applies to other situations?",
       "What did you learn about yourself through this experience?",
       "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflecting Activity", 
        "This activity will help you reflect on your experiences and learn from them by thinking about specific moments in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Take a moment to reflect on the following prompt:");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string prompt = GetRandomPrompt();
            DisplayPrompt(prompt);
            Thread.Sleep(2000);
            string question = GetRandomQuestion();
            DisplayQuestions(question);
            Thread.Sleep(3000); 
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"Prompt: {prompt}");
    }

    public void DisplayQuestions(string questions)
    {
        Console.WriteLine($">>> {questions}\n");
    }
}