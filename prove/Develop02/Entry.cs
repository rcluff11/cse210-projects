using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
    }

    public string ToFileLine(string separator)
    {
        return $"{_date}{separator}{_prompt}{separator}{_response}{separator}{_mood}";
    }

    public static Entry FromFileLine(string line, string separator)
    {
        string[] parts = line.Split(
            new string[] { separator },
            StringSplitOptions.None
        );

        if (parts.Length < 4)
        {
            return new Entry("", "", "", "");
        }

        return new Entry(
            parts[0],
            parts[1],
            parts[2],
            parts[3]
        );
    }
}
