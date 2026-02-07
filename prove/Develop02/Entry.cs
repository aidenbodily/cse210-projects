using System;

class Entry
{
    private string _prompt;
    private string _response;
    private string _date;
    private int _mood;
    
    public Entry(string prompt, string response, string date, int mood)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
        _mood = mood;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}/10");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
    
    public string ToFileString()
    {
        return $"{_date}~|~{_mood}~|~{_prompt}~|~{_response}";
    }
    
    public Entry(string fileLine)
    {
        string[] parts = fileLine.Split("~|~");
        _date = parts[0];
        _mood = int.Parse(parts[1]);
        _response = parts[3];
    }
}