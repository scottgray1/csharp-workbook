using System;
using System.Collections.Generic;

public class Program
{
    // Fields
    // A field is a piece of data (i.e. a type dictionary called stacks)
    private static Dictionary<string, List<int>> stacks = new Dictionary<string, List<int>>()
    {
        { "a", new List<int>() {4, 3, 2, 1} },
        { "b", new List<int>() {} },
        { "c", new List<int>() {} }
    };
    // Methods
    public static void Main()
    {
        while (!GameOver())
        {
            printStacks();

            Console.WriteLine("Enter from stack:");
            string start = Console.ReadLine().ToLower();

            Console.WriteLine("Enter to stack:");
            string finish = Console.ReadLine().ToLower();

            if (isLegal(start, finish) == true)
            {
                movePiece(start, finish);
            }
            else
            {
                Console.WriteLine("It's invalid");
            }
            Console.Clear();
        }
    }
    // check for game over
    public static bool GameOver()
    {
        if (stacks["b"].Count == 4 || stacks["c"].Count == 4)
            return true;
        return false;
    }

    // move piece based on user input
    public static void movePiece(string start, string finish)
    {
        List<int> startStack = stacks[start];
        List<int> finishStack = stacks[finish];
        int movingBlock = startStack[startStack.Count - 1];

        finishStack.Add(movingBlock);
        startStack.Remove(movingBlock);
    }

    // check user entry for legal move
    public static bool isLegal(string start, string finish)
    {
        if (stacks[finish].Count == 0) return true;

        List<int> startStack = stacks[start];
        List<int> finishStack = stacks[finish];

        int movingBlock = startStack[startStack.Count - 1];
        int finishStackLastBlock = finishStack[finishStack.Count - 1];

        if (movingBlock < finishStackLastBlock) return true;

        return false;
    }

    //draw board
    public static void printStacks()
    {
        string[] letters = new string[] { "a", "b", "c" };
        for (var i = 0; i < letters.Length; i++)
        {
            List<string> blocks = new List<string>();
            for (var j = 0; j < stacks[letters[i]].Count; j++)
            {
                blocks.Add(stacks[letters[i]][j].ToString());
            }
            Console.WriteLine(letters[i] + ": " + String.Join("|", blocks));
        }
    }
}
