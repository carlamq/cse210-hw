//Exceeding Requirements: I added a more meaningfull animation fot the breathing activity,
//The text goes fast at the beginning and slow at the end, to simulate a real breathing
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine("Please select an activity to do:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}