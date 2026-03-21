using System;

// base class for all goals, everything shares a name, description, and point value
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // each goal type decides what happens when you record it
    public abstract int RecordEvent();

    // each goal type decides if it's done or not
    public abstract bool IsComplete();

    // each goal type shows itself differently in the list
    public abstract string GetDetailsString();

    // each goal type saves itself to a string differently
    public abstract string GetStringRepresentation();
}
