using System;
using Xunit;


namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void VerifyAddGradeBoundaries()
        {
            // arange
            var book = new Book("My book");
            
            // act
            book.AddGrade(101.0);

            // assert
            Assert.DoesNotContain(101.0, book.grades);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(1.0);
            book.AddGrade(11.19);
            book.AddGrade(91.19);
            
            // act
            var result = book.GetStats();

            // assert
            Assert.Equal(34.46, result.Average, 1);
            Assert.Equal(1.0, result.Low, 1);
            Assert.Equal(91.19, result.High, 1);
            Assert.Equal('F', result.Letter);
        }
    }
}
