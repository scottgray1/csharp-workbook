using System;

public class Program
{
    // possible letters in code
    public static char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

    // size of code
    public static int codeSize = 4;

    // number of allowed attempts to crack the code
    public static int allowedAttempts = 10;

    // number of tried guesses
    public static int numTry = 0;

    // test solution
    public static char[] solution = new char[] { 'a', 'b', 'c', 'd' };

    // game board
    public static string[][] board = new string[allowedAttempts][];

    public static void Main()
    {
        CreateBoard();
        DrawBoard();
        char[] guess = new char[4];

        while (numTry < allowedAttempts)
        {
            Console.WriteLine("Enter Guess:");
            guess = Console.ReadLine().ToCharArray();

            if (CheckSolution(guess))
            {
                Console.WriteLine("You guessed it!");
                return;
            }
            else
            {
                InsertCode(guess);
                Console.WriteLine(GenerateHint(guess));
                Console.WriteLine("Try again");
                numTry++;
                DrawBoard();
            }

        }
        Console.WriteLine("You lose!");
        Console.WriteLine("The correct answer was " + string.Join("", solution));
    }

    public static bool CheckSolution(char[] guess)
    {
        string guessConverted = String.Join("", guess);
        string solutionConverted = String.Join("", solution);

        if (guessConverted == solutionConverted)
        {
            // does match
            return true;
        }
        // doesn't match
        return false;  // could have just done: return (guess == solution) and gotten rid of all the code;
    }

    public static string GenerateHint(char[] guess)
    {
        // create clone of solution
        char[] solutionClone = (char[])solution.Clone();

        // initialize count of correct letter locations
        int correctLetterLocations = 0;

        for (int i = 0; i < solutionClone.Length; i++)
        {
            if (guess[i] == solutionClone[i])
            {
                correctLetterLocations++;
                solutionClone[i] = ' ';
            }
        }
        // initialize count of correct letters
        int correctLetters = 0;
        int targetIndex = 0;

        string s = new string(solution);

        for (int i = 0; i < solutionClone.Length; i++)
        {
            if (solutionClone[i] != ' ')
            {
                targetIndex = s.IndexOf(guess[i]);
                if (targetIndex > -1)
                {
                    correctLetters++;
                }
            }
        }
        return $"You found {correctLetterLocations} letters in the correct location (red pin), You found {correctLetters} letters in the wrong location (white pin)"; ;
    }

    public static void InsertCode(char[] guess)
    {
        for (int i = 0; i < codeSize; i++)
        {
            board[numTry][i] = guess[i].ToString();
        }
        return;
    }

    public static void CreateBoard()
    {
        for (var i = 0; i < allowedAttempts; i++)
        {
            board[i] = new string[codeSize + 1];
            for (var j = 0; j < codeSize + 1; j++)
            {
                board[i][j] = " ";
            }
        }
        return;
    }

    public static void DrawBoard()
    {
        for (var i = 0; i < board.Length; i++)
        {
            Console.WriteLine("|" + String.Join("|", board[i]));
        }
    }

    public static void GenerateRandomCode()
    {
        Random rnd = new Random();
        for (var i = 0; i < codeSize; i++)
        {
            solution[i] = letters[rnd.Next(0, letters.Length)];
        }
        return;
    }
}
