using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Adam's gradebook");
            book.AddGrade(1.0);
            book.AddGrade(11.19);
            book.AddGrade(91.19);
            var result = book.GetStats();

            Console.WriteLine($"Highest grade is: {result.High}");
            Console.WriteLine($"Lowest grade is: {result.Low}");
            Console.WriteLine($"Average of grades is: {result.Average:N1}");
        }
    }
}
