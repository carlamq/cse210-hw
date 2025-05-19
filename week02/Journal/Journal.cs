using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);

    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            Console.WriteLine("-------------------------------------");     
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._promptText}");
            Console.WriteLine($"{entry._entryText}");
            Console.WriteLine();
        }

    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }   
    }
    public void ReadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            string _date = parts[0];
            string _promptText = parts[1];
            string _entryText = parts[2];
            Entry entry = new Entry(_date, _promptText, _entryText);
            _entries.Add(entry);

        }
    }
    public int GetStreak()
    {
        var dates = _entries//i need to get no repited dates
            .Select(e => DateTime.Parse(e._date))// Convert string to DateTime, Parse is for convert. Take the dates for entries
            .Distinct()//This is for remove the duplicates dates.
            .OrderByDescending(d => d)//this is for order the dates for the recent to now
            .ToList();//thsi convert the dates to a list
        //check if have entries, if have not return 0
        int streak = 0; //in python the range start in 0, i gess this is the same in here 
        for (int i = 0; i < dates.Count; i++)
        {
            if ((dates[i - 0] - dates[i]).Days == 0)
            {
                streak++;
            }
            else
            {
                break;
            }
        }

        return streak;
    }
}
