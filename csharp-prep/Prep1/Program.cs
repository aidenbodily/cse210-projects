using System;

class Program
{
    static void Main(string[] args)
    {
        // I added a comment on the next one for my computational thinking so I thought I would go back and explain, I just freeballed this one it was easy enough
        Console.Write("What is your First name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {firstName}, {lastName}.");
    }
}