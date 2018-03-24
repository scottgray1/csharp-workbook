using System;
using System.Collections.Generic;

public class Program
{
    // Fields
    private static Stopwatch _stopwatch;
    private static string _command;

    // Properties

    // Constructor
    static Program()
    {
        _stopwatch = new Stopwatch();
    }

    //Methods
    public static void Main()
    {
        bool started = false;
        bool stopped = false;
        bool reset = false;

        while (_command != "exit")
        {
            Console.Write("Type command (start, stop, reset, laps or exit): ");
            _command = Console.ReadLine().ToLower();

            if (_command == "start")
            {
                started = _stopwatch.Start();

                if (!started)
                {
                    Console.WriteLine("Timer is running, reset it first to start it again.");
                }
            }
            else if (_command == "stop")
            {
                stopped = _stopwatch.Stop();
                if (!stopped)
                {
                    Console.WriteLine("Timer is not runnnig, please start it first.");
                }
            }
            else if (_command == "reset")
            {
                reset = _stopwatch.Reset();
                if (!reset)
                {
                    Console.WriteLine("Timer is not runnnig, please start it first.");
                }
                else
                {
                    Console.WriteLine("Timer has been reset.");
                }
            }
            else if (_command == "laps")
            {
                if (_stopwatch.Laps.Count == 0)
                {
                    Console.WriteLine("No laps have been recorded. Please create a log using the stop command");
                }
                else
                {
                    TimeSpan lap;
                    for (int i = 0; i < _stopwatch.Laps.Count; i++)
                    {
                        lap = _stopwatch.Laps[i];
                        Console.WriteLine($"{(i + 1).ToString("D2")} - {lap.ToString(@"hh\:mm\:ss")} "); // don't get this, copied from Roberto.
                    }
                }
            }
            else if (_command != "exit")
            {
                Console.WriteLine($"`{_command}` is NOT a valid command! Please try gain."); // don't get this, copied from Roberto.
            }
        }
        Console.WriteLine("You exited the application");
        Console.ReadLine();
    }
}

class Stopwatch
{
    // Fields
    private DateTime _startDateTime;
    private DateTime _endDateTime;
    private TimeSpan _elapsedTime;

    // Properties
    public List<TimeSpan> Laps { get; set; }

    // Constructors
    public Stopwatch()
    {
        Laps = new List<TimeSpan>();
    }

    // Methods
    public bool Start()
    {
        if (_startDateTime.Year == DateTime.Now.Year)
            return false;

        _startDateTime = DateTime.Now;

        Console.WriteLine("Timer is running.");

        return true;
    }

    public bool Stop()
    {
        if (_startDateTime.Year != DateTime.Now.Year) // NOTE: .Year appears to make a difference in operability. Research this further.
            return false;

        _endDateTime = DateTime.Now;

        _elapsedTime = _endDateTime.Subtract(_startDateTime);

        Laps.Add(_elapsedTime);

        Console.WriteLine(_elapsedTime.ToString(@"hh\:mm\:ss"));

        return true;
    }

    public bool Reset()
    {
        if (_startDateTime != DateTime.Now)
            return false;

        Laps = new List<TimeSpan>();
        _startDateTime = new DateTime();
        _endDateTime = new DateTime();

        return true;
    }
}

//FAILED ATTEMPTS BELOW - DISREGARD
//public class Program
//{
//    // Fields /
//    private static StopWatch _stopwatch;
//    private static string _command; //user input recepicle 
//                                    // Properties

//    // Constructor

//    static Program()
//    {
//        _stopwatch = new StopWatch(); // initiatizes the class within Program
//    }
//    // Methods

//    public static void Main()
//    {
//        // initialize everything as initially false when the Program starts to support the if statements in the Stopwatch class
//        bool started = false;
//        bool stopped = false;
//        bool reset = false;



//        while (_command != "exit")
//        {

//            // prompt user input
//            Console.WriteLine("Type command(start, stop, reset, laps or exit");
//            _command = Console.ReadLine().ToLower(); // to lower make sure that user input even if in upper and lower case, or all caps all conforms to criteria below

//            switch (_command)
//            {
//                // if user input start
//                case "start":

//                    if (!started)
//                    {
//                        started = _stopwatch.Start();
//                        break;
//                    }
//                    else
//                    {
//                        Console.WriteLine("StopWatch is running. Reset first before attempting to start.");
//                        break;
//                    }

//                // if user input stop
//                case "stop":

//                    stopped = _stopwatch.Stop();

//                    if (!started)
//                    {
//                        Console.WriteLine("Stopwatch is not running. Start it first.");
//                    }
//                    break;

//                // if user input reset
//                case "reset":
//                    if (!reset)
//                    {
//                        reset = _stopwatch.Reset();
//                        Console.WriteLine("StopWatch has been reset.");
//                        break;
//                    }
//                    else
//                    {
//                        Console.WriteLine("StopWatch is not running. Start it first.");
//                        break;
//                    }

//                // if user input laps
//                case "laps":
//                    if (_stopwatch.Laps.Count == 0)
//                    {
//                        Console.WriteLine("No laps have been recorded.");
//                        break;
//                    }
//                    else
//                    {
//                        TimeSpan lap;
//                        for (int i = 0; i < _stopwatch.Laps.Count; i++)
//                        {
//                            lap = _stopwatch.Laps[i];
//                            Console.WriteLine($"{(i + 1).ToString("D2")} - {lap.ToString(@"hh\:mm\:ss")} ");
//                        }
//                        break;
//                    }

//                // if user input anything other than start, stop, reset, laps or exit
//                default:
//                    Console.WriteLine("Please enter a valid command");
//                    break;
//            }
//        }
//        // user input exit and therefore doesn't go through while loop
//        Console.WriteLine("Thank you for using the stopwatch.");
//        Console.ReadLine();
//        */
//        public static void Main()
//        {
//            bool started = false;
//            bool stopped = false;
//            bool reset = false;

//            Console.Clear();
//            Console.WriteLine(">>>StopWatch v1.0<<<");

//            while (_command != "exit")
//            {
//                Console.Write("Type command (start, stop, reset, laps or exit): ");
//                _command = Console.ReadLine().ToLower();

//                Console.Clear();
//                Console.WriteLine(">>>StopWatch v1.0<<<");

//                if (_command == "start")
//                {
//                    started = _stopwatch.Start();

//                    if (!started)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("StopWatch is running, `reset` it first to `start` it again.");
//                        Console.ResetColor();
//                    }
//                }
//                else if (_command == "stop")
//                {
//                    stopped = _stopwatch.Stop();
//                    if (!stopped)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("StopWatch is NOT runnnig, `start` it first.");
//                        Console.ResetColor();
//                    }

//                }
//                else if (_command == "reset")
//                {
//                    reset = _stopwatch.Reset();
//                    if (!reset)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("StopWatch is NOT running, `start` it first.");
//                        Console.ResetColor();
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.Blue;
//                        Console.WriteLine("StopWatch has been `reset` successfully.");
//                        Console.ResetColor();
//                    }
//                }
//                else if (_command == "laps")
//                {
//                    if (_stopwatch.Laps.Count == 0)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("No laps have been recorded.");
//                        Console.ResetColor();
//                    }
//                    else
//                    {
//                        TimeSpan lap;
//                        for (int i = 0; i < _stopwatch.Laps.Count; i++)
//                        {
//                            lap = _stopwatch.Laps[i];
//                            // see: http://bit.ly/2D7nCdN
//                            Console.ForegroundColor = ConsoleColor.DarkCyan;
//                            Console.WriteLine($"{(i + 1).ToString("D2")} - {lap.ToString(@"hh\:mm\:ss")} ");
//                            Console.ResetColor();

//                        }
//                    }
//                }
//                else if (_command != "exit")
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine($"`{_command}` is NOT a valid command! Please try gain.");
//                    Console.ResetColor();
//                }
//            }
//            Console.WriteLine("You exited the StopWatch application successfully.");
//            Console.ReadLine();
//        }
//    }
/*
public class Program
{
    // Fields
    private static Stopwatch _stopwatch;
    private static string _command;

    // Properties
  

    // Constructor
    static Program()
    {
        _stopwatch = new Stopwatch();
    }

    //Methods
    public static void Main()
    {
        bool started = false;
        bool stopped = false;
        bool reset = false;

        Console.Clear();
        Console.WriteLine(">>>StopWatch v1.0<<<");

        while (_command != "exit")
        {
            Console.Write("Type command (start, stop, reset, laps or exit): ");
            _command = Console.ReadLine().ToLower();

            Console.Clear();
            Console.WriteLine(">>>StopWatch v1.0<<<");

            if (_command == "start")
            {
                started = _stopwatch.Start();

                if (!started)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("StopWatch is running, `reset` it first to `start` it again.");
                    Console.ResetColor();
                }
            }
            else if (_command == "stop")
            {
                stopped = _stopwatch.Stop();
                if (!stopped)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("StopWatch is NOT runnnig, `start` it first.");
                    Console.ResetColor();
                }

            }
            else if (_command == "reset")
            {
                reset = _stopwatch.Reset();
                if (!reset)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("StopWatch is NOT running, `start` it first.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("StopWatch has been `reset` successfully.");
                    Console.ResetColor();
                }
            }
            else if (_command == "laps")
            {
                if (_stopwatch.Laps.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No laps have been recorded.");
                    Console.ResetColor();
                }
                else
                {
                    TimeSpan lap;
                    for (int i = 0; i < _stopwatch.Laps.Count; i++)
                    {
                        lap = _stopwatch.Laps[i];
                        // see: http://bit.ly/2D7nCdN
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"{(i + 1).ToString("D2")} - {lap.ToString(@"hh\:mm\:ss")} ");
                        Console.ResetColor();

                    }
                }
            }
            else if (_command != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"`{_command}` is NOT a valid command! Please try gain.");
                Console.ResetColor();
            }
        }
        Console.WriteLine("You exited the StopWatch application successfully.");
        Console.ReadLine();
    }
}

class Stopwatch
{
    // Fields
    private DateTime _startDateTime;
    private DateTime _endDateTime;
    private TimeSpan _elapsedTime;

    // Properties
    public List<TimeSpan> Laps { get; set; }

    // Constructors
    public Stopwatch()
    {
        Laps = new List<TimeSpan>();
    }

    // Methods
    public bool Start()
    {
        /* see: https://www.dotnetperls.com/datetime-format
            MMM     display three-letter month
            ddd     display three-letter day of the WEEK
            d       display day of the MONTH
            HH      display two-digit hours on 24-hour scale
            mm      display two-digit minutes
            yyyy    display four-digit year
        
        //string format = "MMM ddd d HH:mm yyyy";
        //Console.WriteLine(_startDateTime.ToString(format));

        if (_startDateTime.Year == DateTime.Now.Year)
            return false; // stopwatch was already started

        _startDateTime = DateTime.Now;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("StopWatch is running...");
        Console.ResetColor();

        return true;
    }

    public bool Stop()
    {
        if (_startDateTime.Year != DateTime.Now.Year)
            return false; // stopwatch has not been started

        _endDateTime = DateTime.Now;

        _elapsedTime = _endDateTime.Subtract(_startDateTime);

        Laps.Add(_elapsedTime); // add laps

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(_elapsedTime.ToString(@"hh\:mm\:ss"));
        Console.ResetColor();

        return true;
    }

    public bool Reset()
    {
        if (_startDateTime.Year != DateTime.Now.Year)
            return false; // stopwatch has not been started

        Laps = new List<TimeSpan>(); // reinitialize (reset it)
        _startDateTime = new DateTime(); // reinitilize (reset it)
        _endDateTime = new DateTime(); // reinitialize (reset it)

        return true;
    }
}*/
