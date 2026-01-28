using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string Playagain = "";

       do
        {
            Random randomgerator = new Random();
            int Magicnum = randomgerator.Next(1, 101);
            int Guessnum;
            int Guesscount = 0;

            do
            {
                Console.Write("What is your guess? ");
                Guessnum = int.Parse(Console.ReadLine());
                Guesscount++;

                if(Magicnum > Guessnum)
                {
                    Console.WriteLine("Higher");
                } else if (Magicnum < Guessnum){
                    Console.WriteLine("Lower");
                } else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You guessed {Guesscount} times!");
                }
            } while (Guessnum != Magicnum);

            Console.Write("Do you want to play again? (y/n): ");
            Playagain = Console.ReadLine().ToLower();
               
        }while (Playagain == "yes" || Playagain == "y");

    }   
}