using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
    }

    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Scripture file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length != 6)
            {
                continue; // skip malformed lines
            }

            string source = parts[0];
            string book = parts[1];

            if (!int.TryParse(parts[2], out int chapter) ||
                !int.TryParse(parts[3], out int startVerse) ||
                !int.TryParse(parts[4], out int endVerse))
            {
                continue; // skip invalid numeric lines
            }

            string text = parts[5];

            Reference reference = new Reference(book, chapter, startVerse, endVerse);
            Scripture scripture = new Scripture(source, reference, text);

            _scriptures.Add(scripture);
        }
    }

    public void DisplayReferences()
    {
        for (int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scriptures[i].GetReferenceText()} ({_scriptures[i].GetSource()})");
        }
    }

    public Scripture GetByIndex(int index)
    {
        int realIndex = index - 1;

        if (realIndex < 0 || realIndex >= _scriptures.Count)
        {
            return null;
        }

        return _scriptures[realIndex];
    }

    public int Count()
    {
        return _scriptures.Count;
    }
}