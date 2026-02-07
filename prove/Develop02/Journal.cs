using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;
    
    public Journal()
    {
        _entries = new List<Entry>();
    }
    
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }
    
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }
    
    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        
        foreach (string line in lines)
        {
            Entry entry = new Entry(line);
            _entries.Add(entry);
        }
    }
}