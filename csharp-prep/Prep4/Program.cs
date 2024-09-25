using System;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int newNum = 0;
        float numTotal = 0;
        int smallNum = 0;
        int largeNum = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.\n");

        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            newNum = int.Parse(input);

            if (newNum != 0)
            {
                numbers.Add(newNum);
            }
        }while (newNum != 0);

        numbers.Sort();

        foreach (int num in numbers)
        {

            if (largeNum < num)
            {
                largeNum = num;
                smallNum = num;
            }
            if (num > 0)
            {
                if (smallNum > num)
                {
                    smallNum = num;
                }
            }
            numTotal += num;
        }
    
        float numAverage = numTotal / numbers.Count;

        Console.WriteLine($"The sum is: {numTotal}");
        Console.WriteLine($"The average is: {numAverage}");
        Console.WriteLine($"The largest number is: {largeNum}");
        Console.WriteLine($"The smallest positive number is: {smallNum}");
        Console.WriteLine("The sorted list is: ");
        foreach (int num in numbers)
        {
            Console.WriteLine($"{num}");
        }
    }
}