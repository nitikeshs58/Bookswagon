using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using System;
using System.Threading;
using Bookswagon.Screenshots;

namespace Bookswagon.Pages
{
    public class SearchBook
    {
        public IWebDriver driver;
        TakeScreenshot takeScreenshot = new TakeScreenshot();

        public SearchBook(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_txtSearch")]
        public IWebElement searchBook;

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_Button1")]
        public IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//html//body//form//div//div//div//div//div//h1")]
        public IWebElement spanResult;


        public string SearchBookMethod(string bookName)
        {
            Thread.Sleep(3000);
            searchBook.Click();
            searchBook.SendKeys(bookName);
            Thread.Sleep(1000);
            searchButton.Click();
            Thread.Sleep(3000);
            TakeScreenshot();
            return spanResult.Text;
        }

        public void TakeScreenshot()
        {
            TakeScreenshot ts = new TakeScreenshot();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Admin\source\repos\Bookswagon\Bookswagon\Screenshots\" + ts.TakesScreenshotWithDate() + ".png");
        }
    }
}
