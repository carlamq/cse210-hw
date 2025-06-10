using System;

public class ReflectingActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you felt proud of yourself.",
        "Reflect on a challenge you overcame.",
        "Consider a moment when you learned something new.",
        "Recall a time when you helped someone else.",
        "Think about a goal you achieved and how it made you feel."
    };
    private List<string> _questions = new List<string>
    {
        "What did you learn from this experience?",
        "How did it change your perspective?",
        "What emotions did you feel during this time?",
        "What would you do differently if you faced a similar situation again?",
        "How can you apply what you learned to future challenges?"
    };

    public ReflectingActivity()
    {
    }

    public void Run()
    {
        Console.WriteLine("Running reflecting activity...");
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

    public void DisplayPrompt()
    {

    }

    public void DisplayQuestions()
    {

    }
}