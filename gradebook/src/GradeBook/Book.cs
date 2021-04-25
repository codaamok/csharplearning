using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        // This defines a constructor and will execute whenever we use the new keyboard
        // Must be of same name as the class and not have a return type e.g. "void"
        // Constructors are used to build objects when instantiated an object from
        // our class e.g.
        //   var book = new Book();
        // This is instantiating a new object of our class Book in a var named book
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStats()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;
        
            return result;
        }

        private List<double> grades;
        public string Name;
    }
}
