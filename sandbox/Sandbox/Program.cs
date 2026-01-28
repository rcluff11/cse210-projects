using System;

public class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World!");

        //Counter myCounter = new Counter();
        //myCounter.Run();



        Message m1 = new Message();
        m1._message = "Send help!";
        m1._priority = 1;

        Message m2 = new Message();
        m2._message = "Plese pick up some carrots form the store.";
        m2._priority = 3;

        Console.WriteLine(m2.GetMessage());
        Console.WriteLine(m1.GetMessage());
    }
}