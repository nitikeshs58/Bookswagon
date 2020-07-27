using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using System;
using System.Threading;
using Bookswagon.Screenshots;

namespace Bookswagon.Pages
{
    public class Login
    {
        public IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_txtEmail']")]
        public IWebElement userEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_txtPassword']")]
        public IWebElement passWord;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_btnLogin']")]
        public IWebElement loginButton;

        public void LoginBookswagon(string email, string password)
        {

            Thread.Sleep(3000);
            userEmail.SendKeys(email);
            passWord.SendKeys(password);
            loginButton.Click();
            Thread.Sleep(3000);
            TakeScreenshot();
        }

        public void TakeScreenshot()
        {
            TakeScreenshot ts = new TakeScreenshot();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Admin\source\repos\Bookswagon\Bookswagon\Screenshots\" + ts.TakesScreenshotWithDate() + ".png");
        }
    }
}
