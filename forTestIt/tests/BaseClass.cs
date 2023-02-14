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
        private IWebDriver driver;
        public void AfterTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
    }
}
