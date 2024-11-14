using System;
using System.Globalization;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shape = new();

        Square s1 = new("Red", 3);
        shape.Add(s1);

        Rectangle s2 = new("Blue", 4, 5);
        shape.Add(s2);

        Circle s3 = new("Green", 6);
        shape.Add(s3);

        foreach (Shape s in shape)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }

    }
}