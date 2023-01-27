using HW1_Claculator_NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CalculationsTests
{
    [TestFixture]
    public class DevisionTests
    {
        [Test, Category("Devide/Multiply")]
        [TestCaseSource(nameof(DevisionTestData_Success))]
        public void Division_Test(int first, int second)
        {
            int expected = first / second;
            int actual = Calculations.Division(first, second);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<TestCaseData> DevisionTestData_Success()
        {
            yield return new TestCaseData(1, -1);
            yield return new TestCaseData(-1, 1);

            yield return new TestCaseData(0, 1);

            yield return new TestCaseData(0, -2147483647);
            yield return new TestCaseData(0, 2147483647);
        }

        [Test, Category("Devide / Multiply")]
        [TestCaseSource(nameof(DivisionTestData_Exception))]
        public void DivisionTest_Exception(int first, int second)
        {
            var e = Assert.Throws<DivideByZeroException>(() => Calculations.Division(first, second));
            StringAssert.Contains("Attempted to divide by zero.", e.Message.ToString());
        }

        public static IEnumerable<TestCaseData> DivisionTestData_Exception()
        {
            yield return new TestCaseData(1, 0);
            yield return new TestCaseData(0, 0);
            yield return new TestCaseData(-2147483647, 0);
            yield return new TestCaseData(2147483647, 0);
        }
    }
}
