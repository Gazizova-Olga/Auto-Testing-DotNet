using HW1_Claculator_NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalculationsTests
{
    [TestFixture]
    public class SubstractionTests
    {
        [Test, Category("Add/Substruct")]
        [TestCaseSource(nameof(SubstactionTestData_Success))]
        public int Substraction_Test(int first, int second)
        {
            return Calculations.Substraction(first, second);
        }

        public static IEnumerable<TestCaseData> SubstactionTestData_Success()
        {
            yield return new TestCaseData(1, -1).Returns(2);
            yield return new TestCaseData(-1, 1).Returns(-2);

            yield return new TestCaseData(1, 0).Returns(1);
            yield return new TestCaseData(0, 1).Returns(-1);
            yield return new TestCaseData(0, 0).Returns(0);

            yield return new TestCaseData(-2147483648, 0).Returns(-2147483648);
            yield return new TestCaseData(0, -2147483647).Returns(2147483647);
            yield return new TestCaseData(2147483647, 0).Returns(2147483647);
            yield return new TestCaseData(0, 2147483647).Returns(-2147483647);
        }
    }
}
