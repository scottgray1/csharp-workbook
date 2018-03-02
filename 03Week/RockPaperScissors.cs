using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter hand 1:");
        string hand1 = Console.ReadLine().ToLower();
        Console.WriteLine("Enter hand 2:");
        string hand2 = Console.ReadLine().ToLower();
        Console.WriteLine(CompareHands(hand1, hand2));
    }

    public static string CompareHands(string hand1, string hand2)
    {
        //tie
        if (hand1 == hand2)
        {
            Console.WriteLine("It's a tie!");
        }
        //Player 1 Paper
        else if (hand1 == "Paper" && hand2 == "Rock")
        {
            Console.WriteLine("Hand 1 Wins!");
        }
        // Player 1 Scissors
        else if (hand1 == "Scissors" && hand2 == "Paper")
        {
            Console.WriteLine("Hand 1 Wins!");
        }
        // Player 1 Rock
        else if (hand1 == "Rock" && hand2 == "Scissors")
        {
            Console.WriteLine("Hand 1 Wins!");
        }
        //Player 2 Wins
        else
        {
            Console.WriteLine("Hand 2 Wins!");
        }
        Console.ReadLine();
        return hand1 + " " + hand2;
    }
}
