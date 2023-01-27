using HW1_Claculator_NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculationsTests
{
    [TestFixture]
    public class MultiplicationTests
    {
        [Test, Category("Devide/Multiply")]
        [TestCaseSource(nameof(MultiplicationTestData_Success))]
        public void Multiplication_Test(int first, int second)
        {
            int expected = first * second;
            int actual = Calculations.Multiplication(first, second);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<TestCaseData> MultiplicationTestData_Success()
        {
            yield return new TestCaseData(1, -1);
            yield return new TestCaseData(-1, 1);

            yield return new TestCaseData(1, 0);
            yield return new TestCaseData(0, 1);
            yield return new TestCaseData(0, 0);

            yield return new TestCaseData(-2147483648, 0);
            yield return new TestCaseData(0, -2147483648);
            yield return new TestCaseData(2147483647, 0);
            yield return new TestCaseData(0, 2147483647);
        }
    }
}
