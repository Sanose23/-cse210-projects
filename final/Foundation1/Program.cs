using System;
using System.Collections.Generic;

// Comment class
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create some videos
        Video video1 = new Video("Introduction to C#", "Alice", 300);
        Video video2 = new Video("Advanced C# Programming", "Bob", 1800);
        Video video3 = new Video("C# Design Patterns", "Charlie", 1200);
        Video video4 = new Video("C# Best Practices", "Dave", 1500);

        // Add comments to video1
        video1.AddComment(new Comment("John", "Great introduction!"));
        video1.AddComment(new Comment("Jane", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Sam", "Clear and concise."));

        // Add comments to video2
        video2.AddComment(new Comment("Alice", "Learned a lot from this video."));
        video2.AddComment(new Comment("Bob", "Excellent explanations."));
        video2.AddComment(new Comment("Charlie", "Good examples."));

        // Add comments to video3
        video3.AddComment(new Comment("Dave", "Design patterns made easy."));
        video3.AddComment(new Comment("Eve", "Informative video."));
        video3.AddComment(new Comment("Frank", "Very useful."));

        // Add comments to video4
        video4.AddComment(new Comment("Grace", "Best practices indeed!"));
        video4.AddComment(new Comment("Heidi", "This video is gold."));
        video4.AddComment(new Comment("Ivan", "Well presented."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Iterate through the list of videos and display their details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line for better readability
        }
    }
}