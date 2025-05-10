using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = -1;
        int attempts = 0;
        Console.WriteLine("Welcome to the Magic Number Game!");

        while (guess != magicNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher! Try again.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower! Try again.");
            }
            else
            {
                Console.WriteLine($"You've guessed the number {magicNumber} in {attempts} attempts.");
            }
        }
    }
}