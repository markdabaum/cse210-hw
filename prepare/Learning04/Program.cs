using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment assignment = new("Samuel Bennet", "Multiplication", "The Causes of World War II by Mary Waters");
        string summary = $"{assignment.GetSummary()}\n{assignment.GetTitle()}";
        Console.WriteLine($"{summary}");
    }
}