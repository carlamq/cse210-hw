using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userInput = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");
        
        while (userInput != 0)
        {
            Console.WriteLine("Enter a number: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");
        double average = ((double)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max) //For calculating the maximum number
            {
                max = number;
            }
        }
        Console.WriteLine($"The maximum is: {max}");
    }
}