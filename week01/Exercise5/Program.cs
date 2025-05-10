using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string name = PromtUserName();
        int number = PromtUserNumber();
        int square = SquareNumber(number);

        DisplayResult(name, square);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }


    static string PromtUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromtUserNumber()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"Hello {name}, the square of your number is: {square}.");
    }
}