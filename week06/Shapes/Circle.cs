public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Notice the use of the override keyword here
    public override double GetArea()//can use "override" here because this method is defined in the base class
    {
        return _radius * _radius * Math.PI;
    }//programming with classes and objects is important, because it allows to child class personalize the behavior
    //mantaining the same interface as the parent class
}