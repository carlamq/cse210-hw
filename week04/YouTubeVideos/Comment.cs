using System;

public class Comment
{
    private string _author;
    private string _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }
    //have many ways to get and set, (ask later what is better)
    //public string Author
    //{
    //    //get { return _author; }
    //    //set { _author = value; }
    //}
    public string GetAuthor() => _author;
    public string GetText() => _text;

    //public string GetAuthor()
    //{
    //    return _author;
    //}
}