using System; //for can use consosle, String, DateTime, etc.
using System.Collections.Generic; //list and dictionarys
using System.IO;//for can read and write files
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)//cosntructor
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; //No end verse, default to 0
    }
    public Reference(string book, int chapter, int verse, int endVerse)//cosnturctor with end verse
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse} ";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse} ";
        }
    }
}
public class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false; 
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        //text.Split(' ') divide the text bt spaces to get words
        //Select(word => new Word(word)) creates a new Word object for each word in the text, for can be a list
    }
    public void HideRandomWords(int numberToHide)
    {
        //create a lis of visible words that contain only letters
        List<Word> visibleWords = new List<Word>();
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                visibleWords.Add(w);
            }        
        }
        var rand = new Random();//for generate random numbers and hide random numbers words
        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)//loop to repite until hide all
        {
            int idx = rand.Next(visibleWords.Count);//choose a random index from the visible words
            visibleWords[idx].Hide();//hide the word
            visibleWords.RemoveAt(idx);//remove the hidden word for not hide it twice
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        foreach (Word w in _words)
        {
            referenceText += w.GetDisplayText() + " "; //append each words display text
        }
        return referenceText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;//if have at least one word not hidden
            }
        }
        return true; //if all words are hidden
    }
    public string GetOriginalText()//to show the original text without hidden words again
    {
        string result = "";
        foreach (Word w in _words)
        {
            string wordText = w.GetDisplayText().Replace("_", "");
            result += wordText + " ";
        }
        return result.Trim();//.Trim remove extra speces in the text, strar end
    }
}
class Program
{
    static void Main()
    {   
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("This program will help you memorize scriptures by hiding random words.");
        Console.WriteLine("You can type 'quit' at any time to exit the program.");
        Console.WriteLine("Press Enter to start...");
        Console.ReadLine(); //wait for the enter
    
        //read from a file
        var scriptures = new List<Scripture>();
        foreach (var line in File.ReadAllLines("scriptures.txt"))
        {
            var parts = line.Split('|');
            var referenceParts = parts[0].Split(' ');
            var book = referenceParts[0];
            var chapterVerse = referenceParts[1].Split(':');
            var chapter = int.Parse(chapterVerse[0]);
            var verse = int.Parse(chapterVerse[1].Split('-')[0]);
            int endVerse = chapterVerse[1].Contains('-') ? int.Parse(chapterVerse[1].Split('-')[1]) : 0;
            var reference = endVerse > 0 ? new Reference(book, chapter, verse, endVerse) : new Reference(book, chapter, verse);
            scriptures.Add(new Scripture(reference, parts[1]));
        }

        // Select the fist scripture to start
        var scripture = scriptures[0];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); //number of words to hide

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You have memorized the scripture:");
                Console.WriteLine(scripture.GetOriginalText());
                Console.WriteLine("\nPress Enter to continue to the next scripture or type 'quit' to exit.");
                input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit")
                    break;

                // Move to the next scripture
                int currentIndex = scriptures.IndexOf(scripture);
                if (currentIndex < scriptures.Count - 1)
                {
                    scripture = scriptures[currentIndex + 1];
                }
                else
                {
                    Console.WriteLine("You have completed all scriptures!");
                    break;
                }
            }
        }
    }
}