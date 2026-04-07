using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("10 Best Budget Laptops 2024", "TechReviewHub", 743);
        video1.AddComment(new Comment("Alice", "Great review, very helpful!"));
        video1.AddComment(new Comment("Bob", "I just bought the #3 pick, love it."));
        video1.AddComment(new Comment("Carlos", "Would love to see a follow-up on tablets."));
        videos.Add(video1);

        Video video2 = new Video("How to Make Sourdough Bread", "BreadBakerPro", 1254);
        video2.AddComment(new Comment("Dana", "My loaf turned out perfect, thank you!"));
        video2.AddComment(new Comment("Eli", "What brand of flour do you recommend?"));
        video2.AddComment(new Comment("Fiona", "I had to watch this three times but got it."));
        video2.AddComment(new Comment("George", "Best sourdough tutorial on YouTube."));
        videos.Add(video2);

        Video video3 = new Video("Beginner Yoga for Stress Relief", "ZenFlowYoga", 2100);
        video3.AddComment(new Comment("Hannah", "This really helped me after a long day."));
        video3.AddComment(new Comment("Ivan", "How often should beginners do this?"));
        video3.AddComment(new Comment("Julia", "Subscribed immediately after this video!"));
        videos.Add(video3);

        Video video4 = new Video("Day in My Life as a Software Engineer", "CodeWithSam", 987);
        video4.AddComment(new Comment("Kevin", "Super motivating, just started CS!"));
        video4.AddComment(new Comment("Lena", "What laptop are you using?"));
        video4.AddComment(new Comment("Marco", "Love the honesty about long meetings."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("==============================================");
            video.Display();
            Console.WriteLine();
        }
    }
}