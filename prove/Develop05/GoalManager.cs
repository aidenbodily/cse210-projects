using System;
using System.Collections.Generic;
using System.IO;

// this class handles all the goal management stuff, adding, recording, saving, loading
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public int GetScore()
    {
        return _score;
    }

    // every 1000 points you go up a level
    private void UpdateLevel()
    {
        _level = 1 + (_score / 1000);
    }

    private string GetLevelTitle()
    {
        if (_level >= 10) return "legend";
        if (_level >= 7) return "hero";
        if (_level >= 5) return "adventurer";
        if (_level >= 3) return "apprentice";
        return "beginner";
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nyou have {_score} points | level {_level} ({GetLevelTitle()})\n");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("no goals yet. go create some!");
            return;
        }

        Console.WriteLine("\nyour goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nwhat type of goal?");
        Console.WriteLine("  1. simple goal (one-time)");
        Console.WriteLine("  2. eternal goal (ongoing)");
        Console.WriteLine("  3. checklist goal (do it x times)");
        Console.Write("pick one: ");

        string choice = Console.ReadLine();

        Console.Write("goal name: ");
        string name = Console.ReadLine();
        Console.Write("short description: ");
        string description = Console.ReadLine();
        Console.Write("points per event: ");

        int points;
        if (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.WriteLine("that's not a number, try again next time");
            return;
        }

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("how many times to complete it? ");
                int target;
                if (!int.TryParse(Console.ReadLine(), out target))
                {
                    Console.WriteLine("not a number, bailing out");
                    return;
                }
                Console.Write("bonus points when finished: ");
                int bonus;
                if (!int.TryParse(Console.ReadLine(), out bonus))
                {
                    Console.WriteLine("not a number, bailing out");
                    return;
                }
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("not a valid choice");
                return;
        }

        Console.WriteLine("goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("no goals to record against, make some first");
            return;
        }

        ListGoals();
        Console.Write("which goal did you accomplish? (number): ");

        int index;
        if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("invalid choice");
            return;
        }

        Goal goal = _goals[index - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("that goal is already complete!");
            return;
        }

        int earned = goal.RecordEvent();

        if (earned > 0)
        {
            Console.WriteLine($"nice! you earned {earned} points!");
        }

        _score += earned;

        int oldLevel = _level;
        UpdateLevel();
        if (_level > oldLevel)
        {
            Console.WriteLine($"level up! you are now level {_level} - {GetLevelTitle()}");
        }

        if (goal.IsComplete())
        {
            Console.WriteLine($"you completed the goal: {goal.GetName()}!");
        }

        Console.WriteLine($"total score: {_score}");
    }

    public void SaveGoals()
    {
        Console.Write("filename to save to: ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("need a filename");
            return;
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score}|{_level}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("saved!");
    }

    public void LoadGoals()
    {
        Console.Write("filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("file not found");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("empty file");
            return;
        }

        _goals.Clear();

        string[] playerData = lines[0].Split('|');
        _score = int.Parse(playerData[0]);
        _level = playerData.Length > 1 ? int.Parse(playerData[1]) : 1;

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;
            }
        }

        Console.WriteLine("loaded!");
    }
}
