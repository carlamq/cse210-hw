using System;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments; //create the lis

    public Video(string title, string author, int length)//constructor for setting the values
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();//set the list
    }
    public void AddComment(Comment comment)//getter
    {
        _comments.Add(comment);
    }
    public int GetCommentCount()//getter
    {
        return _comments.Count;
        // _comments is the list and .Count is a property that returns the number of elements in the list
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments: {_comments.Count}");
        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.GetAuthor()}: {comment.GetText()}");
        }
        //Its the same as write all lines myself, but this is more cool
        Console.WriteLine("\n" + new string('-', 40) + "\n");
        //Console.WriteLine("\n ----------------------------------------\n"); 
    }
}   