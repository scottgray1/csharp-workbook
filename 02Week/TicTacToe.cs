using System;

public class Program
{
    public static string playerTurn = "X";
    public static string[][] board = new string[][]
    {
        new string[] {" ", " ", " "},
        new string[] {" ", " ", " "},
        new string[] {" ", " ", " "}
     };

    public static void Main()
    {
        do
        {
            DrawBoard();
            GetInput();

        } while (CheckForWin() == false && !CheckForTie());

        // leave this command at the end so your program does not close automatically
        Console.ReadLine();
    }

    public static void GetInput()
    {
        // asking for which player turn
        Console.WriteLine("Player " + playerTurn);
        // asking for row
        Console.WriteLine("Enter Row:");
        // stores user input
        int row = Int32.Parse(Console.ReadLine());
        // asks for column
        Console.WriteLine("Enter Column:");
        // stores user input 
        int column = Int32.Parse(Console.ReadLine());

        // Place a mark We are collecting a row and a column from the prompt.
        PlaceMark(row, column);

        // Run CheckForWin() after every time you place the mark, but before you switch players. Also checks for tie
        if (CheckForWin())
        {
            DrawBoard();
            Console.WriteLine("Player " + playerTurn + " Won!");
            return;
        }
        else if (CheckForTie())
        {
            DrawBoard();
            Console.WriteLine("It's a tie!");
            return;
        }

        // Alternate between the players
        playerTurn = (playerTurn == "X") ? "O" : "X";
    }

    public static void PlaceMark(int row, int column)
    {
        // We have access to the global playerTurn variable, which is set to X by default. Set the place on the board to playerTurn instead of "X"
        board[row][column] = playerTurn;
        return;
    }

    public static bool CheckForWin()
    {
        // if any return as true, log "Player " + playerTurn + " Won!"
        if (HorizontalWin() || VerticalWin() || DiagonalWin())
        {
            return true;
        }
        return false;
    }
    public static int SlotsAvailable()
    {
        int openSlots = 0;

        foreach (var row in board)
        {
            foreach (var column in row)
            {
                if (column != "X" && column != "O")
                {
                    openSlots++;
                }
            }
        }
        return openSlots;
    }

    public static bool CheckForTie()
    {
        bool tie = false;
        tie = SlotsAvailable() == 0 ? true : false;

        return tie;
    }

    public static bool HorizontalWin()
    {
        // Check all three spots in each horizontal row to see if they all match the current player turn.
        if (board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn ||  // Top Row
            board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn ||  // Middle Row
            board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn) // Bottom Row
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool VerticalWin()
    {
        // Check all three spots in each vertical row to see if they all match the current player turn.
        if (board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn || // First column
            board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn || // Middle Column
            board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn) // Last Column
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool DiagonalWin()
    {
        // Check all three spots in each diagonal row to see if they all match the current player turn.
        if (board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn || // Diagonal Left to Right
            board[0][2] == playerTurn && board[1][1] == playerTurn && board[2][0] == playerTurn) // Diagonal Right to Left
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void DrawBoard()
    {
        Console.WriteLine("  0 1 2");
        Console.WriteLine("0 " + String.Join("|", board[0]));
        Console.WriteLine("  -----");
        Console.WriteLine("1 " + String.Join("|", board[1]));
        Console.WriteLine("  -----");
        Console.WriteLine("2 " + String.Join("|", board[2]));
        Console.WriteLine("                  "); // added white space for readablity.
    }
}
