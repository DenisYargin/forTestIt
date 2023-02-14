using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forTestIt.tests
{
    public class BaseClass
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTheTests()
        {
            _webDriver = new ChromeDriver();
        }

        [TearDown]
        protected void DoAfterEach()
        {
            _webDriver.Quit();
        }

        [SetUp]
        protected void DobeforeEach()
        {
            _webDriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
