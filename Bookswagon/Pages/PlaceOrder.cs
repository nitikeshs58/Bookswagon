using System;
using System.Threading;
using Bookswagon.Screenshots;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;

namespace Bookswagon.Pages
{
    public class PlaceOrder
    {
        public IWebDriver driver;

        public PlaceOrder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
        }

        [FindsBy(How = How.XPath, Using = "//div[1]//div[4]//div[5]//a[1]//input[1]")]
        public IWebElement buyNowButton;

        [FindsBy(How = How.XPath, Using = "//iframe[@class='cboxIframe']")]
        public IWebElement cartFrame;

        [FindsBy(How = How.XPath, Using = "//html//body//form//div//div//h1")]
        public IWebElement myCartHeader;

        [FindsBy(How = How.XPath, Using = "//input[@id='BookCart_lvCart_imgPayment']")]
        public IWebElement placeOrderButton;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/form[1]/div[3]/div[3]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/a[1]")]
        public IWebElement continueButton;

        public string BookOrder()
        {
            buyNowButton.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(cartFrame);
            Thread.Sleep(5000);
            TakeScreenshot();
            Thread.Sleep(3000);
            string cartHeader = myCartHeader.Text;
            placeOrderButton.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            continueButton.Click();
            return cartHeader;
        }

        public void TakeScreenshot()
        {
            TakeScreenshot ts = new TakeScreenshot();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Admin\source\repos\Bookswagon\Bookswagon\Screenshots\" + ts.TakesScreenshotWithDate() + ".png");
        }
    }
}
