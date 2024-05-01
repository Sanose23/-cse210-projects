using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guess = 0;

        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I have picked a number between 1 and 100.");
        Console.WriteLine("Try to guess it!");

        while (guess != magicNumber)
        {
            Console.Write("Enter your guess: ");
            guess = Convert.ToInt32(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
