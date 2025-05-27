using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {// Default constructor initializes to 1/1
     // This constructor sets the fraction to 1/1
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {// Constructor that takes a whole number and sets the fraction using it, takes onlu one integer
     // This constructor sets the fraction to wholeNumber/1
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {//creates a normal fraction using the 2 string values
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {// method, returns the format of the fraction
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()//returns a floating-point value (decimal)
    {
        return (double)_top / (double)_bottom;//(double) convert the int to float, so the divition is more precise
    }
    static void Main(string[] args) //the main class is the entry point of the program
    {
        Fraction f1 = new Fraction();//have no parameters, so it will use the default constructor
        Console.WriteLine(f1.GetFractionString()); // 1/1
        Console.WriteLine(f1.GetDecimalValue()); // 1.0

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString()); // 5/1
        Console.WriteLine(f2.GetDecimalValue()); // 5.0

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString()); // 3/4
        Console.WriteLine(f3.GetDecimalValue()); // 0.75

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString()); // 1/3
        Console.WriteLine(f4.GetDecimalValue()); // 0.3333333333333333
    }
}