using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;//does not need a parameter for _isComplete because all new simple goals should always start as incomplete (false)

    }
    public override int RecordEvent()
    {
        //implementation for recording the event
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    
    public override string GetStringRepresentation()//converts the object to a string representation for saving to a file
    {
        return $"SimpleGoal: {_shortName}, {_description}, {_points}, Completed: {_isComplete}";
    }//its important because it allows to save it in the text file and load it, also can separate the elements in the text

}