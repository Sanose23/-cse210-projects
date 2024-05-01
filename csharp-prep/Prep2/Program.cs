using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirements
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Write a series of if-else statements to determine the letter grade
        char letter;
        if (gradePercentage >= 90)
            letter = 'A';
        else if (gradePercentage >= 80)
            letter = 'B';
        else if (gradePercentage >= 70)
            letter = 'C';
        else if (gradePercentage >= 60)
            letter = 'D';
        else
            letter = 'F';

        // Determine if the user passed the course
        bool passed;
        string message;
        if (gradePercentage >= 70)
        {
            passed = true;
            message = "Congratulations! You passed the course.";
        }
        else
        {
            passed = false;
            message = "Don't worry, keep working hard for next time!";
        }

        // Print the letter grade and pass/fail message
        Console.WriteLine($"Your letter grade is: {letter}");
        Console.WriteLine(message);

        // Stretch Challenge
        // Determine if the grade has a "+" or "-" sign
        char sign = DetermineSign(gradePercentage, letter);

        // Print the letter grade and sign
        Console.WriteLine($"Your adjusted grade is: {letter}{sign}");
    }

    // Method to determine the sign (+/-) based on the grade percentage and letter grade
    static char DetermineSign(double gradePercentage, char letter)
    {
        if (70 <= gradePercentage && gradePercentage < 90 && letter != 'F')
        {
            int lastDigit = (int)(gradePercentage % 10);
            if (lastDigit >= 7)
                return '+';
            else if (lastDigit < 3)
                return '-';
            else
                return ' ';
        }
        else
        {
            return ' ';
        }
    }
}
