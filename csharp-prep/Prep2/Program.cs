using System;

class Program
{
    static void Main(string[] args)
    {
        // Computational Thinking
        // Get input, parse it, then compare with multiple if statements then return output based on score
        // Probably could optimize with loops but idk how to do that yet
        Console.Write("What grade did you get? ");
        string gradeInput = Console.ReadLine();
        int gradeCompare = int.Parse(gradeInput);
        string letter = string.Empty;
        if (gradeCompare >= 93)
        {
            letter = "A";
        }
        else if (gradeCompare < 93 && gradeCompare >= 90)
        {
            letter = "A-";
        }
        else if (gradeCompare < 90 && gradeCompare >= 87)
        {
            letter = "B+";
        }
        else if (gradeCompare < 87 && gradeCompare >= 83)
        {
            letter = "B";
        }
        else if (gradeCompare < 83 && gradeCompare >= 80)
        {
            letter = "B-";
        }
        else if (gradeCompare < 80 && gradeCompare >= 77)
        {
            letter = "C+";
        }
        else if (gradeCompare < 77 && gradeCompare >= 73)
        {
            letter = "C";
        }
        else if (gradeCompare < 73 && gradeCompare >= 70)
        {
            letter = "C-";
        }
        else if (gradeCompare < 70 && gradeCompare >= 67)
        {
            letter = "D+";
        }
        else if (gradeCompare < 67 && gradeCompare >= 63)
        {
            letter = "D";
        }
        else if (gradeCompare < 63 && gradeCompare >= 60)
        {
            letter = "D-";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"You scored a {letter}");
        if (gradeCompare >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Unfortunately you failed the class, but if you study hard, you can pass next time!");
        }


    }
}