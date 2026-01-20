using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What grade did you get? ");
        string grade = Console.ReadLine();
        int gradeNumber = int.Parse(grade);

        if (gradeNumber >= 93)
        {
            Console.WriteLine("A");
        }
        else if (gradeNumber >= 90)
        {
            Console.WriteLine("A-");
        }
        else if (gradeNumber >= 87)
        {
            Console.WriteLine("B+");
        }
        else if (gradeNumber >= 84)
        {
            Console.WriteLine("B");
        }
        else if (gradeNumber >= 80)
        {
            Console.WriteLine("B-");
        }
        else if (gradeNumber >= 77)
        {
            Console.WriteLine("C+");
        }
        else if (gradeNumber >= 74)
        {
            Console.WriteLine("C");
        }
        else if (gradeNumber >= 70)
        {
            Console.WriteLine("C-");
        }
        else if (gradeNumber >= 67)
        {
            Console.WriteLine("D+");
        }
        else if (gradeNumber >= 64)
        {
            Console.WriteLine("D");
        }
        else if (gradeNumber >= 60)
        {
            Console.WriteLine("D-");
        }
        else
        {
            Console.WriteLine("F");
        }


    }
}