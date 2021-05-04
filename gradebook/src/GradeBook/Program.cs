using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Adam's gradebook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var result = book.GetStats();

            Console.WriteLine($"Name of the grade book: {book.Name}");
            Console.WriteLine($"Number of grades entered: {result.Count}");
            Console.WriteLine($"Highest grade is: {result.High}");
            Console.WriteLine($"Lowest grade is: {result.Low}");
            Console.WriteLine($"Average of grades is: {result.Average:N1} ({result.Letter})");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added!");
        }

        private static void EnterGrades(Book book)
        {
            string input;
            do
            {
                Console.WriteLine("Please enter a grade (q to exit):");
                input = Console.ReadLine();
                if (input != "q")
                {
                    try
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Double.Parse(): {ex.Message}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"AddGrade(): {ex.Message}");
                    }
                }
            } while (input != "q");
        }
    }
}
