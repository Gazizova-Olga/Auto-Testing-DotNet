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
        public int Addition_Test(int first, int second)
        {
            return Calculations.Addition(first, second);
        }

        public static IEnumerable<TestCaseData> AdditionTestData_Success()
        {
            yield return new TestCaseData(1, -1).Returns(0);
            yield return new TestCaseData(-1, 1).Returns(0);

            yield return new TestCaseData(1, 0).Returns(1);
            yield return new TestCaseData(0, 1).Returns(1);
            yield return new TestCaseData(0, 0).Returns(0);

            yield return new TestCaseData(-2147483648, 0).Returns(-2147483648);
            yield return new TestCaseData(0, -2147483648).Returns(-2147483648);
            yield return new TestCaseData(2147483647, 0).Returns(2147483647);
            yield return new TestCaseData(0, 2147483647).Returns(2147483647);
        }
    }
}
