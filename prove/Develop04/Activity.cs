using System;
using System.Threading;

abstract class Activity
{
    // shared fields for every activity type
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        // same start message for all activities
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");

        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
        }

        _duration = duration;
        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        // same ending message for all activities
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
    }
    
    public void ShowSpinner(int seconds)
    {
        // super simple spinner loop
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b \b");
            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("\\");
            Thread.Sleep(200);
            Console.Write("\b \b");
            if (DateTime.Now >= endTime)
            {
                break;
            }
        }
    }

    public void ShowCountdown(int seconds)
    {
        // basic countdown used by activities
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected int GetDuration()
    {
        return _duration;
    }

    public abstract void Run();
}
