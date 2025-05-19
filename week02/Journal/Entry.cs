using System;
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string prompt, string entryText)
    {
        _date = date;
        _promptText = prompt;
        _entryText = entryText;
    }

    public void Display()
    {
        //Im not sure id i should put something here... is a void so dont need to return anything, works correctly but maybe is not the best way
        //ask later****
    }
}