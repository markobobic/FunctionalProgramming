using Chapter01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
