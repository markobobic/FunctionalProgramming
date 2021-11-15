using Chapter01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Linq.ParallelEnumerable;


namespace Chapter01Tests
{
    [TestClass]
    public class FirstSolutionsTests
    {
        [TestMethod]
        public void Negate_Predicate_Test_1()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Func<int, bool> oddNumbersPredicate = num => num % 2 == 1;

            var evenNumbers = numbers.Where(oddNumbersPredicate.Negate()).ToList();

            Assert.IsTrue(evenNumbers[0] == 2);
            Assert.IsTrue(evenNumbers[1] == 4);
            Assert.IsTrue(evenNumbers[2] == 6);
        }

        [TestMethod]
        public void Quick_Sort_Test_2()
        {
            var numbers = new List<int>() { 2, 6, 4, 5, 3, 1 };
            var expectedResults = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Assert.IsTrue(numbers.QuickSort().SequenceEqual(expectedResults));
        }

        [TestMethod]
        public void Quick_Sort_Test_3()
        {
            var list = new List<string>() { "bananas", "JAGODA", "Breskva" };

            var toSentance =  list.AsParallel().Select(FirstSolutions.ToSentanceCase)
                .Zip(Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();


        }
    }
}
