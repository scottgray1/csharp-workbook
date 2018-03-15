using System;

public class Program
{
    public static string _command;

    public static void Main()
    {
        var newPost = new BlogPost
        {
            Title = "New Post",
            Description = "New Post Description."
        };
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("-------------------------");
        Console.WriteLine(newPost.Title);
        Console.WriteLine(newPost.Description);
        Console.WriteLine(newPost.CreationDateTime);
        Console.WriteLine("-------------------------");
        Console.ResetColor();
        do
        {
            //Console.WriteLine("Number of votes: " + newPost.DisplayVotes());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Please type 'Upvote' or 'Downvote'. Or 'Exit' to close.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            _command = Console.ReadLine().ToLower();
            Console.ResetColor();

            switch (_command)
            {
                case "upvote":
                    newPost.UpVote();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Total votes:" + newPost.DisplayVotes());
                    Console.ResetColor();
                    break;

                case "downvote":
                    newPost.DownVote();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Total votes:" + newPost.DisplayVotes());
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid command");
                    Console.ResetColor();
                    break;

            }
        } while (_command != "exit");

    }
}



class BlogPost
{
    public string Title { get; set; }
    public string Description { get; set; }
    public readonly DateTime CreationDateTime = DateTime.Now;
    private int _votes = 0;


    public int DisplayVotes()
    {
        return _votes;
    }

    public void UpVote()
    {
        _votes++;
    }

    public void DownVote()
    {
        _votes--;
    }
}
