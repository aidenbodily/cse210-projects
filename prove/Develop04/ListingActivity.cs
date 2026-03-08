using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    // prompt options for this activity
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();
    private int _itemCount;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        // shared start screen from the base class
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine("--- " + GetRandomPrompt() + " ---");
        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);
        Console.WriteLine("\n");

        // count how many answers the user enters before time ends
        _itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _itemCount++;
        }

        Console.WriteLine("\nYou listed " + _itemCount + " items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        // pick one random prompt
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
