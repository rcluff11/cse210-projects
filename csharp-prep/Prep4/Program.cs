using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int Enternumber = -1;
        while(Enternumber != 0)
        {
            Console.Write("Enter a number (Enter 0 to quit): ");

            string Numberstr = Console.ReadLine();
            Enternumber = int.Parse(Numberstr);

            if (Enternumber != 0)
            {
                numbers.Add(Enternumber);
            }
        }

        int sum = 0;
        
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is {average}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is {max}");
    }
}