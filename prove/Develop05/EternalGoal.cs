using System;

// eternal goal, never truly done, you just keep getting points every time
public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public EternalGoal(string name, string description, int points, int timesCompleted) : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return GetPoints();
    }

    // eternal goals are never complete, that's the whole point
    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} ({GetDescription()}) -- recorded {_timesCompleted} time(s)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_timesCompleted}";
    }
}
