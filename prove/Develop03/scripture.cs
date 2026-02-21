using System;
using System.Collections.Generic;

public class Scripture
{
    private string _source;
    private Reference _reference;
    private List<Word> _words;
    private Random _rng;

    public Scripture(string source, Reference reference, string text)
    {
        _source = source;
        _reference = reference;
        _words = new List<Word>();
        _rng = new Random();

        string[] tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string token in tokens)
        {
            _words.Add(new Word(token));
        }
    }

    public string GetSource()
    {
        return _source;
    }

    public string GetReferenceText()
    {
        return _reference.ToString();
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference} {string.Join(" ", displayWords)}";
    }

    public bool HideWordByIndex(int index)
    {
        int realIndex = index - 1;

        if (realIndex < 0 || realIndex >= _words.Count)
        {
            return false;
        }

        if (_words[realIndex].IsHidden())
        {
            return false;
        }

        _words[realIndex].Hide();
        return true;
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            return;
        }

        int randomIndex = _rng.Next(visibleWords.Count);
        visibleWords[randomIndex].Hide();
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