using Chapter02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter02Tests
{
    [TestClass]
    public class SecondSolutionTests
    {
        [TestMethod]
        public void Test_CalculateBmi_1()
        {
            Assert.IsTrue(Bmi.CalculateBmi(77, 1.80) == 23.77);
        }
        [TestMethod]
        public void Test_CalculateBmi_2()
        {
            Assert.IsTrue(23.77.ToBmiRange() == BmiRange.Healthy);
            Assert.IsTrue(30.08.ToBmiRange() == BmiRange.Overweight);
        }

        [TestMethod]
        public void Test_ReadBmi_1()
        {
            var result = default(BmiRange);
            Bmi.Run(Read, Write);

            double Read(string s) => s == "weight" ? 77 : 1.80;
            void Write(BmiRange r) => result = r;
            Assert.IsTrue(result == BmiRange.Healthy);
        }
    }

}
