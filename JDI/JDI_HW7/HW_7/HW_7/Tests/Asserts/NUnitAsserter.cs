using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDI_Matchers.NUnit;

namespace HW_7.Tests.Asserts
{
    public class NUnitAsserter : Assert
    {
        public NUnitAsserter()
        {
        }

        public NUnitAsserter(string checkMessage) : base()
        {
        }
    }
}
