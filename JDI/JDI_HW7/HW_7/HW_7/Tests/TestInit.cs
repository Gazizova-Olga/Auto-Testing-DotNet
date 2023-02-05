using Epam.JDI.Core.Settings;
using HW_7.Project.Entities;
using HW_7.Project.Site;
using JDI_Web.Selenium.DriverFactory;
using JDI_Web.Selenium.Elements.Composite;
using JDI_Web.Settings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.Tests
{
    [SetUpFixture]
    public class TestInit
    {
        public static SiteJdi SiteJdi { get; set; }

        [OneTimeSetUp]
        protected void SetUp()
        {
            WebSettings.Init();
            var logger = JDISettings.Logger;
            logger.Info("Init test run...");
            WinProcUtils.KillAllRunWebDrivers();
            WebSite.Init(typeof(SiteJdi));
            logger.Info("Run test...");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            // Some log outputs
            WinProcUtils.KillAllRunWebDrivers();
        }
    }
}
