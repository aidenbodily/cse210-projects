using System;

class Program
{
    static void Main(string[] args)
    {
        // completely forgot to do computational thinking on this one i just thugged it out
        string playagain = "yes";
        while(playagain == "yes")
            {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            // Console.Write("What is the magic number? ");
            // string magic = Console.ReadLine();
            // int magicNumber = int.Parse(magic);
            int guessNumber;
            int guesses = 0;
            do
            {
                guesses++;
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guessNumber = int.Parse(guess);
                if(guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if(guessNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                
            }
            while (guessNumber != magicNumber);
            Console.WriteLine($"You guessed it! It took you {guesses} guesses!");
            Console.WriteLine("Do you want to play again? (yes/no) ");
            playagain = Console.ReadLine();
        }
    }
}