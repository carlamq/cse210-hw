using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        //Video 1
        Video video1 = new Video("How to bake a cake", "Chef Ramsay", 1500);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Can't wait to try this!"));
        video1.AddComment(new Comment("Charlie", "Looks delicious!"));
        video1.AddComment(new Comment("Dave", "How do I make it gluten-free?"));
        videos.Add(video1);
        //Video 2
        Video video2 = new Video("Learn C# in 10 minutes", "Jane Smith", 600);
        video2.AddComment(new Comment("Dave", "Very informative!"));
        video2.AddComment(new Comment("Eve", "I love this tutorial!"));
        video2.AddComment(new Comment("Frank", "Not useful at all."));
        videos.Add(video2);
        //Video 3
        Video video3 = new Video("Travel Vlog: Paris", "John Doe", 2400);
        video3.AddComment(new Comment("Alice", "Beautiful views!"));
        video3.AddComment(new Comment("Bob", "Need visa to visit?"));
        video3.AddComment(new Comment("Charlie", "Great tips for traveling!"));
        videos.Add(video3);

        //loop for display the information
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}