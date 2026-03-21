using System;

// exceeding requirements:
// added a leveling system: every 1000 points you level up and get a new title
// (beginner, apprentice, adventurer, hero, legend). it shows your level next to
// your score and tells you when you level up after recording a goal.

// computational thinking:
// the main idea here is breaking the problem into smaller pieces. each goal type is its own class
// but they all share the same interface through the base class. that way the goal manager doesn't
// need to know what kind of goal it's dealing with, it just calls recordevent() and gets back points.
// that's polymorphism doing the heavy lifting. the save/load system uses a simple text format where
// each goal knows how to turn itself into a string and we can rebuild it from that string later.
// the whole thing is really just decomposition and abstraction working together so each piece
// handles its own logic without the other pieces needing to care.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        Console.WriteLine("welcome to eternal quest!");
        Console.WriteLine("track your goals, earn points.\n");

        while (running)
        {
            manager.DisplayPlayerInfo();

            Console.WriteLine("menu:");
            Console.WriteLine("  1. create new goal");
            Console.WriteLine("  2. list goals");
            Console.WriteLine("  3. record event");
            Console.WriteLine("  4. save goals");
            Console.WriteLine("  5. load goals");
            Console.WriteLine("  6. quit");
            Console.Write("what would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    manager.SaveGoals();
                    break;
                case "5":
                    manager.LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("keep questing! see you next time.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("not sure what that means, try a number 1-6");
                    break;
            }
        }
    }
}