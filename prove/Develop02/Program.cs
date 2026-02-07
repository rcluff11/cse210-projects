using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public Journal _journal = new Journal();
    public PromptGenerator _prompts = new PromptGenerator();
    public static void Main(string[] args)
    {
        Program p = new Program();
        p.ShowMenu();
    }

    public void ShowMenu()
    {
        string choice = "";
        
        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteNewEntry();
            }
            else if (choice == "2")
            {
                DisplayJournal();
            }
            else if (choice == "3")
            {
                SaveJournal();
            }
            else if (choice == "4")
            {
                LoadJournal();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye");
                break;
            }
        }
    }

    public void WriteNewEntry()
    {
        string prompt = _prompts.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry entry = new Entry(date, prompt, response);
        _journal.AddEntry(entry);
    }

    public void DisplayJournal()
    {
        _journal.DisplayAll();
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter fliename: ");
        string filename = Console.ReadLine();
        _journal.SaveToFile(filename);
        Console.WriteLine("Journal Saved.");
    }

    public void LoadJournal()
    {
        Console.WriteLine("Enter filename: ");
        string filename = Console.ReadLine();
        _journal.LoadFromFile(filename);
    }
}

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileLine("|"));
            }
        }
        _entries.Clear();
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        
        foreach(string line in lines)
        {
            Entry entry = Entry.FromFileLine(line, "|");
            _entries.Add(entry);
        }
    }
}

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }

    public string ToFileLine(string seperator)
    {
        return $"{_date}{seperator}{_prompt}{seperator}{_response}";
    }

    public static Entry FromFileLine(string line, string seperator)
    {
        string [] parts = line.Split(new string [] {seperator}, StringSplitOptions.None);

        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];

        return new Entry(date, prompt, response);
    }
}

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "When did I feel God’s help today, even in a small way?",
        "What moment today reminded me that God is aware of me?",
        "How did God answer a prayer recently—directly or indirectly?",
        "Where did I notice unexpected peace today?",
        "When did something work out better than I expected?",
        "What challenge today helped me rely more on God?",
        "How did God guide a decision I made recently?",
        "When did I feel protected today?",
        "What tender mercy did I notice today?",
        "Who did God place in my path for a reason today?",
        "When did I feel prompted to do something small but important?",
        "How did God show patience with me today?",
        "When did I feel comfort that I couldn’t explain?",
        "What experience recently strengthened my trust in God?",
        "How did God help me through something difficult today?",
        "What blessing today would have been easy to overlook?",
        "What simple gift from God made today better?",
        "What am I grateful for that I usually take for granted?",
        "How has God blessed my family recently?",
        "What part of my day felt quietly sacred?",
        "What do I feel most thankful to God for right now?",
        "How has God helped provide for my needs?",
        "What relationship in my life feels like a blessing from God?",
        "What opportunity today came from God’s timing?",
        "What strength has God helped me develop?",
        "What is God trying to teach me right now?",
        "How am I growing because of a recent trial?",
        "What fear do I need to give to God?",
        "Where do I need more faith in my life?",
        "What does God want me to become?",
        "How can I better listen for God’s guidance?",
        "What habit could help me feel closer to God?",
        "How can I invite God into my daily routine more intentionally?",
        "What part of my life do I need to trust God with more fully?",
        "How has my relationship with God changed recently?",
        "When has God helped me before in a similar situation?",
        "What past experience reminds me that God is faithful?",
        "What prayer has already been answered that I should remember today?",
        "What moment in my life clearly shows God’s hand?",
        "When was a time God carried me when I felt weak?",
        "What miracle in my life have I forgotten to acknowledge?",
        "What spiritual experience do I never want to forget?",
        "How has God helped me grow over the past year?",
        "What challenge did God already help me overcome?",
        "How can I remember God’s goodness when life feels hard?",
        "How did God help me bless someone else today?",
        "Who might God be inviting me to serve right now?",
        "When did I feel love for someone that felt bigger than my own?",
        "How can I be an answer to someone else’s prayer?",
        "How did God help me show patience or kindness today?",
        "How did I feel God’s love for me today?",
        "When did I feel that God understands me personally?",
        "What reminds me that I am a child of God?",
        "How can I better reflect Christ in my life?",
        "What does God see in me that I sometimes forget?",
        "What worry can I place in God’s hands tonight?",
        "What hope has God placed in my heart recently?",
        "How can I show more trust in God tomorrow?",
        "What is one way I can act on faith this week?",
        "What do I want to remember about God’s goodness today before I sleep?"
    };

    public Random _random = new Random();

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "You have used all available prompts.";
        }
        int index = _random.Next(_prompts.Count);
        string prompt = _prompts[index];

        _prompts.RemoveAt(index);
        return prompt;
    }
}