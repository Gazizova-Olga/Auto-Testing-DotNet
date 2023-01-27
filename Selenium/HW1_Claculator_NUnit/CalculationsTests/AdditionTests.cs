using HW1_Claculator_NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculationsTests
{
    [TestFixture]
    public class AdditionTests
    {
        [Test, Category("Add/Substruct")]
        [TestCaseSource(nameof(AdditionTestData_Success))]
        public void Addition_Test(int first, int second)
        {
            int expected = first + second;
            int actual = Calculations.Addition(first, second);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<TestCaseData> AdditionTestData_Success()
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
