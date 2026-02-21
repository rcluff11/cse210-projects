// My attempt at creativity I added a feature that allows you to both randomly hide words as you go
// or hide words by the index -1 so it's a little easier to understand. So if i wanted to hide
// the third word is would enter 3,
using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        library.LoadFromFile("scriptures.txt");

        Console.WriteLine("Available Scriptures:");
        library.DisplayReferences();
        Console.WriteLine();

        Console.Write("Select a scripture by number: ");
        string selectionInput = Console.ReadLine();

        if (!int.TryParse(selectionInput, out int selection))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Scripture scripture = library.GetByIndex(selection);

        if (scripture == null)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide a random word.");
            Console.WriteLine("Enter a number (starting at 1) to hide a specific word.");
            Console.WriteLine("Type 'q' to quit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                scripture.HideRandomWord();
                continue;
            }

            if (int.TryParse(input, out int index))
            {
                bool success = scripture.HideWordByIndex(index);

                if (!success)
                {
                    Console.WriteLine("Invalid index or word already hidden.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}