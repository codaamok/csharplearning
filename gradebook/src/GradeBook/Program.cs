using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Adam's gradebook");
            //book.AddGrade(1.0);
            //book.AddGrade(11.19);
            //book.AddGrade(91.19);

            string input;
            do {
                Console.WriteLine("Please enter a grade (q to exit):");
                input = Console.ReadLine();
                if (input != "q") {
                    try {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Double.Parse(): {ex.Message}");
                    }
                    catch (ArgumentException ex) {
                        Console.WriteLine($"AddGrade(): {ex.Message}");
                    }
                } 
            } while (input != "q");

            var result = book.GetStats();

            Console.WriteLine($"Number of grades entered: {result.Count}");
            Console.WriteLine($"Highest grade is: {result.High}");
            Console.WriteLine($"Lowest grade is: {result.Low}");
            Console.WriteLine($"Average of grades is: {result.Average:N1} ({result.Letter})");
        }
    }
}
