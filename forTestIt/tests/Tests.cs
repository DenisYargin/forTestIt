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
    public class Tests : BaseClass
    {
        string testIt = "Test It";

        [Test(Description = "Позитивный кейс, поиск канала TestIt")]
        public void CheckFindTestIt()
        {            
            var youtube = new MainYoutubePage(_webDriver);
            youtube.InputYoutubeSearch(testIt);           
            Assert.IsTrue(youtube.CheckElementExist(testIt), "Страница не содержит данного элемента в DOM");
            Assert.IsTrue(youtube.CheckTextExist(), "Страница не содержит данной строки");
        }


        [Test(Description = "Позитивный кейс, поиск 7го видео")]
        public void ChekFindVideo10()
        {
            var youtube = new MainYoutubePage(_webDriver);
            youtube.InputYoutubeSearch(testIt);
            var testPage = new TestItPage(_webDriver);
            testPage.SelectChannel();
            testPage.SelectSorted();
            testPage.SelectVideoInArrayList();
            Assert.IsTrue(testPage.CheckVideoOpen());
        }
    }
}
