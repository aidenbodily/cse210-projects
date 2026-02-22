using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] wordsFromText = text.Split(' ');
        foreach (string part in wordsFromText)
        {
            if (part != "")
            {
                _words.Add(new Word(part));
            }
        }
    }

    public void HideRandom()
    {
        int wordsToHide = 3;
        int hiddenThisRound = 0;
        int maxAttempts = _words.Count * 2;
        int attempts = 0;

        while (hiddenThisRound < wordsToHide && attempts < maxAttempts)
        {
            attempts++;
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenThisRound++;
            }
        }
    }

    public string GetDisplay()
    {
        string displayText = _reference.GetDisplay() + " ";

        for (int i = 0; i < _words.Count; i++)
        {
            displayText += _words[i].GetDisplay();

            if (i < _words.Count - 1)
            {
                displayText += " ";
            }
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
