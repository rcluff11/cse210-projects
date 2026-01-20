using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("   ----------------------");
        Console.WriteLine("   | YOUR FAMILY TREE   |");
        Console.WriteLine("   ----------------------");
        Console.Write("What is yout Paternal Grandfather's name? ");
        string Pgrandpa = Console.ReadLine();
        Console.Write("What is your Paternal Grandmother's name? ");
        string Pgrandma = Console.ReadLine();

        Console.Write("What is yout Maternal Grandfather's name? ");
        string Mgrandpa = Console.ReadLine();
        Console.Write("What is your Maternal Grandmother's name? ");
        string Mgrandma = Console.ReadLine();

        Console.Write("What is your Father's name? ");
        string Dad = Console.ReadLine();
        Console.Write("What your Mother's name? ");
        string Mom = Console.ReadLine();

        Console.Write("What is your name? ");
        string Name = Console.ReadLine();

        Console.WriteLine($"    {Pgrandpa}           {Mgrandpa} ");
        Console.WriteLine($"    {Pgrandma}          {Mgrandma} ");
        Console.WriteLine( "      |                |     ");
        Console.WriteLine( "      |                |     ");
        Console.WriteLine( "      ------------------     ");
        Console.WriteLine( "              |              ");
        Console.WriteLine( "              |              ");
        Console.WriteLine($"            {Dad}            ");
        Console.WriteLine($"            {Mom}            ");
        Console.WriteLine( "              |              ");
        Console.WriteLine( "              |              ");
        Console.WriteLine($"            {Name}           ");
    }
}