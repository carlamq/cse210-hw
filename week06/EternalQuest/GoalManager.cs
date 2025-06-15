using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>(); //necessary only for GoalManager
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)//each case call a method with a specific functionality
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Stop a Bad Habit Goal");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        int points = 0;
        switch (type)
        {
            case "1":
                points = 100; //Default points for Simple Goal
                _goals.Add(new SimpleGoal(name, description, points));
                break;//_goals is the list that creat new object for the class SimpleGoal
            case "2":
                points = 100;
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                points = 50;
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                int bonus = 500;
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                int dailyPoints = 150;
                int relapsePenalty = 75;
                Console.WriteLine($"If you do not relapse, you will earn {dailyPoints} points daily. If you relapse, you will lose {relapsePenalty} points.\n");
                _goals.Add(new BadHabitGoal(name, description, points, relapsePenalty, dailyPoints));
                break;

        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            //GetDetailsString will call each goal's method to get its details
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)//need show details first so usedthe same loop
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;//-1 because the list starts from 0, but user input starts from 1
        int points = _goals[choice].RecordEvent();//call the RecordEvent method of the selected goal
        _score += points; //add points to the total score
        Console.WriteLine($"You earned {points} points! Total score: {_score}");
        Thread.Sleep(500);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved! Press Enter to continue...");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            Console.ReadLine();
            return;
        }
        _goals.Clear();//need to clear the existing goals before loading new ones for do not mix
        string[] lines = System.IO.File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);//read the first line for the score 
        for (int i = 1; i < lines.Length; i++)//1 because 0 is the score line
        {
            //start with order to read the information, first the : split
            string[] parts = lines[i].Split(':');
            string type = parts[0];//can take the first part wich is the type of goal
            string[] data = parts[1].Split(',');

            switch (type)//check the type, then create the case for each one
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        data[0].Trim(),//0 is the name, 1 is description, 2 is points
                        data[1].Trim(),
                        int.Parse(data[2].Trim())
                    ));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(//need add new object because was text file, need become object again to work the methods
                        data[0].Trim(),
                        data[1].Trim(),
                        int.Parse(data[2].Trim())
                    ));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        data[0].Trim(),
                        data[1].Trim(),
                        int.Parse(data[2].Trim()),
                        int.Parse(data[4].Trim()),//target count
                        int.Parse(data[5].Trim())//bonus points
                    ));
                    break;
                case "BadHabitGoal":
                    _goals.Add(new BadHabitGoal(
                        data[0].Trim(),
                        data[1].Trim(),
                        int.Parse(data[2].Trim()),//daily points
                        int.Parse(data[3].Trim()),//relapse penalty
                        int.Parse(data[4].Trim())//days without relapse
                    ));
                    break;
            }
        }
        Console.WriteLine("Goals loaded! Press Enter to continue...");
        Console.ReadLine();
    }
}