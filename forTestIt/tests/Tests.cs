using Allure.Commons;
using forTestIt.pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V107.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forTestIt.tests
{
    [TestFixture]
    public class Tests 
    {
        private IWebDriver _webDriver;
        string testIt = "Test It";

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test(Description = "Позитивный кейс, поиск канала TestIt")]
       
        public void CheckFindTestIt()
        { 
            
            var youtube = new YoutubePage(_webDriver);
            youtube.InputYoutubeSearch(testIt);           
            Assert.IsTrue(youtube.CheckElementExist(testIt), "Страница не содержит данной строки");
        }

        [Test(Description = "Позитивный кейс, поиск 7го видео")]
        public void ChekFindVideo10()
        {
            var youtube = new YoutubePage(_webDriver);
            youtube.InputYoutubeSearch(testIt);
            var testPage = new TestItPage(_webDriver);
            testPage.SelectChannel();
            
            testPage.SelectVideo();
            
            
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
