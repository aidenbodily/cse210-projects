using System;
using System.Data;
using System.Net.NetworkInformation;

class Program
{
    // no real computational thinking it was just a bunch of small easy problems
    // DisplayWelcome - Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // PromptUserName - Asks for and returns the user's name (as a string)
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string number = Console.ReadLine();
        int favoriteNumber = int.Parse(number);
        return favoriteNumber;

    }

    // PromtUserBirthYear - Accepts out integer parameter and prompts the user for the year they were born. The out parameter is set to their birth year. This function does not return a value. The user's birth year is given back from the function via the out parameter.
    // this one is misspelled in the instructions lol
    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("What year were you born? ");
        string year = Console.ReadLine();
        birthYear = int.Parse(year);
    }

    // SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)

    static int SquareNumber(int inputNumber)
    {
        int squared = inputNumber * inputNumber;
        return squared;
    }
    // DisplayResult - Accepts the user's name, the squared number, and the user's birth year. Display the user's name and squared number. Calculate hold many years old they will turn this year and display that.
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{name}, The square of your number is {squaredNumber}");
        int age = 2026 - birthYear;
        Console.WriteLine($"{name}, You will turn {age} years old this year!");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int numberSquared = SquareNumber(userNumber);
        PromtUserBirthYear(out int year);
        DisplayResult(userName, numberSquared, year);
    }
}