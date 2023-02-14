using forTestIt.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace forTestIt.pages
{
    public class TestItPage
    {
        public IWebDriver _webDriver;
        private readonly By _selectChannel = By.XPath("//div[@id = 'content-section']");
        private readonly By _allTheDatesVideo = By.XPath("//yt-formatted-string[@id = 'video-title' and ancestor::a[@id='video-title-link'] and ancestor::ytd-rich-grid-media and ancestor::ytd-rich-item-renderer and ancestor::ytd-rich-grid-row]/ancestor::a");
        private readonly By _video = By.XPath("//*[@id=\"tabsContent\"]/tp-yt-paper-tab[2]");
        private readonly By _sortedVideo = By.XPath("//ytd-two-column-browse-results-renderer[@class='style-scope ytd-browse grid grid-6-columns']");
        private readonly By _videoSelect = By.XPath("//div[@id='player-theater-container']");

        public TestItPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /*
         * Выбор вкладки "Видео" и клик по нему.
         */
        public void SelectChannel()
        {
            _webDriver.FindElement(_selectChannel).Click();
            _webDriver.FindElement(_video).Click();
        }

        /*
         * Метод для того чтобы дочерние элементы Dom были кликабельны.
         */
        public void SelectSorted()
        {
            _webDriver.FindElement(_sortedVideo).Click();
        }

        /*
         * Выбор 7го видео по дате обновления. + Явное ожидание, пока элемент не станет кликабельным.
         */
        public void SelectVideoInArrayList()
        {
            var wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 30));
            List<IWebElement> list;
            list = _webDriver.FindElements(_allTheDatesVideo).ToList();
            var element = list[7];
            var _video = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            _video.Click();
        }

        /*
         * Проверка, что видео открылось.
         */
        public bool CheckVideoOpen() => _webDriver.FindElement(_videoSelect).Displayed;

        public void SelectVideoJavaExecutor()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_webDriver;
            IList<IWebElement> all = _webDriver.FindElements(_allTheDatesVideo);
            executor.ExecuteScript("arguments[6].click();", all);
        }

    }
}

     
    

            

    
          
        

   

        
        
          
    

