using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 10.1, 98.9, 50.0 };
            grades.Add(56.1);

            var total = 0.0;
            foreach(double number in grades)
            {
                total += number;
            }
            
            if (args.Length > 0)
            {
                // String concatenation
                Console.WriteLine("Hello " + args[0] + "!");
                // String interpolation
                Console.WriteLine($"Hello {args[0]}!");
            }
            else {
                Console.WriteLine($"Total is: {total}");
                Console.WriteLine($"Average of grades is: {(total / grades.Count):N1}");
            }
        }
    }
}
