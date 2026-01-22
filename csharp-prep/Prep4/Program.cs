using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        // computational thinking (this one is harder for my brain)
        // make a list
        // have the user give inputs as long as its not 0
        // calculate the things it wants
        Console.WriteLine("Hello Prep4 World!");

        // make a list
        List<int> numbers = new List<int>();
        // have the user give inputs until "0"
        int inputNumber = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while(inputNumber != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            inputNumber = int.Parse(input);
            numbers.Add(inputNumber);
        }
        // calculate the sum, average, and maximum of the list
        // sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // average
        float average = (float)sum / (numbers.Count - 1);
        Console.WriteLine($"The average is: {average}");

        // maximum
        int maxNumber = 0;
        foreach (int number in numbers)
        {
            if(number > maxNumber)
            {
                maxNumber = number;
            }
        }
        Console.WriteLine($"The largest number is: {maxNumber}");
        // sort the list smallest to largest:
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}