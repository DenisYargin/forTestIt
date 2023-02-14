using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forTestIt.pages
{
    public class YoutubePage
    {

        public IWebDriver _webDriver;
        public readonly string URL_YOUTUBE = "https://www.youtube.com/";
        public readonly By _searchInput = By.XPath("//input[@id='search']");
        public readonly By text = By.XPath(".//*[text()='@TestITTMS']/ancestor::ytd-channel-renderer");

        public YoutubePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public void InputYoutubeSearch(string input)
        {
            _webDriver.Navigate().GoToUrl(URL_YOUTUBE);
            var findTest = _webDriver.FindElement(_searchInput);
            findTest.SendKeys(input);
            findTest.SendKeys(Keys.Enter);
        }

        public bool CheckElementExist(string stringSearch)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(e => e.PageSource.Contains(stringSearch));
            try
            {
                return _webDriver.PageSource.Contains(stringSearch);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool CheckTextExist() => _webDriver.FindElement(text).Displayed;
    }
}






