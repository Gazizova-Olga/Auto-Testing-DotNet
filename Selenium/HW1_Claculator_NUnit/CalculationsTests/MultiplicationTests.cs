using HW1_Claculator_NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculationsTests
{
    [TestFixture]
    public class MultiplicationTests
    {
        [Test, Category("Rising")]
        [TestCaseSource(nameof(MultiplicationTestData_Success))]
        public int Addition_Test(int first, int second)
        {
            return Calculations.Multiplication(first, second);
        }

        public static IEnumerable<TestCaseData> MultiplicationTestData_Success()
        {
            yield return new TestCaseData(1, -1).Returns(-1);
            yield return new TestCaseData(-1, 1).Returns(-1);

            yield return new TestCaseData(1, 0).Returns(0);
            yield return new TestCaseData(0, 1).Returns(0);
            yield return new TestCaseData(0, 0).Returns(0);

            yield return new TestCaseData(-2147483648, 0).Returns(0);
            yield return new TestCaseData(0, -2147483648).Returns(0);
            yield return new TestCaseData(2147483647, 0).Returns(0);
            yield return new TestCaseData(0, 2147483647).Returns(0);
        }
    }
}
