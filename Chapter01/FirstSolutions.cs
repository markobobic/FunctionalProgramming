using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter01
{
    public static class FirstSolutions
    {
        public static Func<T, bool> Negate<T>(this Func<T, bool> predicate) =>
            t => !predicate(t);

        public static List<int> QuickSort(this List<int> source)
        {
            if (!source.Any())
                return new List<int>();

            var pivot = source.FirstOrDefault();
            var restOfNumbers = source.Skip(1).ToList();

            Func<int,bool> smallerNumbersPredicate = num => num <= pivot;

            var smallerNumbersThanPivot = restOfNumbers.Where(smallerNumbersPredicate).ToList();
            var biggerNumbersThanPivot = restOfNumbers.Where(smallerNumbersPredicate.Negate()).ToList();

            return smallerNumbersThanPivot.QuickSort()
                .Append(pivot)
                .Concat(biggerNumbersThanPivot.QuickSort())
                .ToList();
        }

        public static List<T> QuickSort<T>(this List<T> source, Comparison<T> compare)
        {
            if (!source.Any())
                return new List<T>();

            var pivot = source.First();
            var restOfNumbers = source.Skip(1).ToList();
            
            var smallerNumbersThanPivot = restOfNumbers.Where(num => compare(num, pivot) < 1).ToList();
            var biggerNumbersThanPivot = restOfNumbers.Where(num => compare(num, pivot) >= 1).ToList();

            return smallerNumbersThanPivot.QuickSort(compare)
                .Append(pivot)
                .Concat(biggerNumbersThanPivot.QuickSort(compare))
                .ToList();
        }

        public static R Using<TDisp, R>(Func<TDisp> createDisposable, Func<TDisp, R> func)
            where TDisp : IDisposable
        {
            using var disp = createDisposable();
            return func(disp);
        }
    }
}
