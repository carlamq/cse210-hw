using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string userInput = "";
        while (userInput != "5")
        {
            int streak = journal.GetStreak();
            if (streak > 0)
                Console.WriteLine($"Congratulations! You have written in your journal for {streak} consecutive days.");
            else
                Console.WriteLine("Welcome! Start your streak by writing today.");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load from file");
            Console.WriteLine("4. Save to file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine("Remembet to choose 'Save to file' after writing your entry.");//seems if you dont push save it will not save
                Console.WriteLine(prompt);
                string entryText = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                Entry newEntry = new Entry(theCurrentTime.ToShortDateString(), prompt, entryText);
                journal.AddEntry(newEntry);
            }
            else if (userInput == "2")
            {
                journal.DisplayAll();
            }
            else if (userInput == "3")
            {
                journal.ReadFromFile("journal.txt");
            }
            else if (userInput == "4")
            {
                journal.SaveToFile("journal.txt");
            }
            else if (userInput == "5")
            {
                Console.WriteLine("See you tomorrow! Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option, please try again. Remember use only numbers from 1 to 5");
            }
        }
    }
}