using System;

class Program
{
    static void Main(string[] args)
    {
        // Prepping my variables
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letterGrade = "NA";
        string gradeModifier = "";
        string passedOrFailed = "";

        // Defining the grade scale
        if (grade >= 90)
        {
            letterGrade = "A";
            if (grade < 93)
            {
                gradeModifier = "-";
            }
        }
        else if (grade < 60)
        {
            letterGrade = "F";
        }
        
        else
        {
            if (grade >= 80)
            {
            letterGrade = "B";
            }
            else if (grade >= 70)
            {
                letterGrade = "C";
            }
            else if (grade >= 60)
            {
                letterGrade = "D";
            }
            

            // Defining "+" or "-" modifiers
            if (grade % 10 >= 3)
            {
                gradeModifier = "+";
            }
            else if (grade % 10 < 3)
            {
                gradeModifier = "-";
            }
        }

        if (grade >= 70)
        {
            passedOrFailed = "passed";
        }
        else
        {
            passedOrFailed = "failed";
        }
        // Print
        Console.WriteLine($"Your grade: {letterGrade}{gradeModifier}");
        Console.WriteLine($"You {passedOrFailed}");
    }
}
