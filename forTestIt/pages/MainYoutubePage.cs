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
    public class MainYoutubePage
    {
        public IWebDriver _webDriver;
        public readonly By _searchInput = By.XPath("//input[@id='search']");
        public readonly By _text = By.XPath(".//*[text()='@TestITTMS']/ancestor::ytd-channel-renderer");
      
        public MainYoutubePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /*
         * Метод, который вводит {string} в поле ввода и клик по поиску
         */
        public void InputYoutubeSearch(string input)
        {
            var findTest = _webDriver.FindElement(_searchInput);
            findTest.SendKeys(input);
            findTest.SendKeys(Keys.Enter);
        }

        /*
         * Универсальный метод, который ищет {string} в dom элементах страницы.
         */
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

        /*
         *  Метод, для проверки присутствия элемента
         */
        public bool CheckTextExist() => _webDriver.FindElement(_text).Displayed;
    }
}






