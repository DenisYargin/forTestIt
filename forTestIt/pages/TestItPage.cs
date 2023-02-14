using forTestIt.helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace forTestIt.pages
{
    public class TestItPage
    {
        public IWebDriver _webDriver;
        private readonly By _selectChannel = By.XPath("//div[@id = 'content-section']");
        private readonly By _allTheDatesVideo = By.XPath(".//yt-formatted-string[@id = 'video-title' and ancestor::a[@id='video-title-link'] and ancestor::ytd-rich-grid-media and ancestor::ytd-rich-item-renderer and ancestor::ytd-rich-grid-row]/ancestor::a");
        private readonly By _video = By.XPath("//*[@id=\"tabsContent\"]/tp-yt-paper-tab[2]");


        public TestItPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void SelectChannel()
        {
            _webDriver.FindElement(_selectChannel).Click();
            _webDriver.FindElement(_video).Click();
        }
        // public List<string> ListVideo => _webDriver.FindElements(_allTheDatesVideo).Select(x => x.Click).ToList();
        public void SelectVideo()
        {
            List<IWebElement> list;
           list = _webDriver.FindElements(_allTheDatesVideo).ToList();
            Thread.Sleep(5000);
            
            list[7].Click();
            Thread.Sleep(5000);






        }

    }
}

     
    

            

    
          
        

   

        
        
          
    

