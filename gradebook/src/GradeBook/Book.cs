using System;
using System.Collections.Generic;

namespace Gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book : NamedObject
    {
        // This defines a constructor and will execute whenever we use the new keyboard
        // Must be of same name as the class and not have a return type e.g. "void"
        // Constructors are used to build objects when instantiated an object from
        // our class e.g.
        //   var book = new Book();
        // This is instantiating a new object of our class Book in a var named book
        public Book(string name) : base(name)
        {
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'E':
                    AddGrade(50);
                    break;
                case 'F':
                    AddGrade(0);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <=100) 
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"Invalid grade");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStats()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Count = grades.Count;

            var i = 0;
            do
            {
                result.High = Math.Max(grades[i], result.High);
                result.Low = Math.Min(grades[i], result.Low);
                result.Average += grades[i];
                i++;
            } while (i < grades.Count);

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
        
            return result;
        }

        public List<double> grades;
        public const string category = "science";
    }
}
