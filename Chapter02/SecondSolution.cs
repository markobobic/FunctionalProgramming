using System;

namespace Chapter02
{
    using static Console;
    using static Math;
    
    public enum BmiRange { Underweight, Healthy, Overweight }

    public static class Bmi
    {
        public static void Run()
            => Run(Read, Write);

        public static void Run(Func<string, double> read, Action<BmiRange> write)
        {
            var weight = read("weight");
            var height = read("height");
            var bmiRange = CalculateBmi(weight, height).ToBmiRange();
            write(bmiRange);
        }

        public static double CalculateBmi(double weight, double height)
            => Round(weight / Pow(height, 2), 2);

        public static BmiRange ToBmiRange(this double bmi)
            => bmi < 18.5 ? BmiRange.Underweight : 25 <= bmi ? BmiRange.Overweight : BmiRange.Healthy;

        private static double Read(string field)
        {
            WriteLine($"Please enter your {field}");
            return double.Parse(ReadLine());
        }

        private static void Write(BmiRange bmiRange)
            => WriteLine($"Based on your BMI, you are {bmiRange}");
    }
}
