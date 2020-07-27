using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using System;
using System.Threading;

namespace Bookswagon.Pages
{
    public class Logout
    {
        IWebDriver driver;
        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_lnkbtnLogout")]
        public IWebElement logoutButton;

        public void LogoutBookswagon()
        {
            Thread.Sleep(2000);
            logoutButton.Click();
        }
    }
}
