using Bookswagon.Credentials;
using Bookswagon.Screenshots;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;

namespace Bookswagon.Pages
{
    public class Checkout
    {
        public IWebDriver driver;

        public Checkout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewRecipientName")]
        public IWebElement RecipientNameBox;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewCompanyName")]
        public IWebElement CompanyNameBox;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewAddress")]
        public IWebElement AddressBox;

        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_cpBody_ddlNewCountry']")]
        public IWebElement CountryDropdown;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_cpBody_plnShippingAdd']//option[107]")]
        public IWebElement SelectCountry;

        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_cpBody_ddlNewState']")]
        public IWebElement StateDropdown;

        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_cpBody_divddlNewState']//option[23]")]
        public IWebElement SelectState;
        
        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewCity")]
        public IWebElement NewCity;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewPincode")]
        public IWebElement NewPincode;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewPhone")]
        public IWebElement NewPhone;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewMobile")]
        public IWebElement NewMobile;
        
        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_cpBody_imgSaveNew']")]
        public IWebElement SaveAndContinueButton;
        
        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_savecontinue")]
        public IWebElement ProceedToPaymentButton;


        public void ChechOutCart()
        {
            Thread.Sleep(5000);
            RecipientNameBox.Click();
            Thread.Sleep(5000);
            RecipientNameBox.SendKeys(JsonData.data.RecipientName);
            Thread.Sleep(5000);
            CompanyNameBox.Click();
            Thread.Sleep(5000);
            CompanyNameBox.SendKeys(JsonData.data.CompanyName);
            Thread.Sleep(5000);
            AddressBox.SendKeys(JsonData.data.StreetAddress);
            Thread.Sleep(5000);
            CountryDropdown.Click();
            Thread.Sleep(3000);
            SelectCountry.Click();
            Thread.Sleep(3000);
            StateDropdown.Click();
            Thread.Sleep(3000);
            SelectState.Click();
            Thread.Sleep(3000);
            NewCity.SendKeys(JsonData.data.City);
            Thread.Sleep(5000);
            NewPincode.SendKeys(JsonData.data.PinCode);
            Thread.Sleep(5000);
            NewPhone.SendKeys(JsonData.data.Phone);
            Thread.Sleep(5000);
            NewMobile.SendKeys(JsonData.data.Mobile);
            Thread.Sleep(5000);
            TakeScreenshot();
            Thread.Sleep(5000);
            SaveAndContinueButton.Click();
            Thread.Sleep(5000);
            ProceedToPaymentButton.Click();
        }

        public void TakeScreenshot()
        {
            TakeScreenshot ts = new TakeScreenshot();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Admin\source\repos\Bookswagon\Bookswagon\Screenshots\" + ts.TakesScreenshotWithDate() + ".png");
        }
    }
}
