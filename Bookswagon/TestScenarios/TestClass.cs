// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Bookswagon.Pages;
using Bookswagon.Credentials;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Security.Policy;
using System.Net.Mail;
using System.Net;
using Bookswagon.MailReport;

namespace Bookswagon
{
    [TestFixture]
    public class TestClass
    { 
        // Declarations
        ExtentReports extent = null;
        ExtentTest test = null;
        public IWebDriver driver;

        /// <summary>
        /// 1) creating object of ExtentReports
        /// 2) htmlReporter ->Contains the path of file where , extents reports is going to stored
        /// 3) extent-> takes the argument of ExtenthtmlReporter
        /// 4) launch the chrome browser
        /// 5) Maximize the browser window
        /// 6) Sends Url
        /// </summary>
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Admin\source\repos\Bookswagon\Bookswagon\ExtentReports\BookswagonReport.html");
            extent.AttachReporter(htmlReporter);
            test = extent.CreateTest("LoginTestMethod").Info("Test Started");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Chrome browser launched");
            driver.Url = JsonData.data.Url;
            test.Log(Status.Info, "Sent url of Bookswagon to address bar");
        }

        [Test,Order(1)]
        public void LoginTestMethod()
        {
            try
            {
                Login login = new Login(driver);
                login.LoginBookswagon(JsonData.data.UserEmail, JsonData.data.Password);
                test.Log(Status.Info, "UserEmail and password entered in textbox");
                string title = driver.Title;
                test.Log(Status.Info, "Got the homepage title of Bookswagon");
                Assert.AreEqual(JsonData.data.title, title);
                test.Log(Status.Pass, "Test passed");
            }
            catch(Exception exception)
            {
                test.Log(Status.Fail, exception.ToString());
                throw;
            }
        }

        [Test, Order(2)]
        public void SearchBookTestMethod()
        {
            try
            {
                test = extent.CreateTest("SearchBookTestMethod").Info("Search Book Test Started");
                SearchBook addwish = new SearchBook(driver);
                string spanResult=addwish.SearchBookMethod(JsonData.data.BookTitleToSearch);
                test.Log(Status.Info, "Book is searched");
                string expectedSpanResult = "positive thinking";
                spanResult.Contains(expectedSpanResult);
                test.Log(Status.Pass, "Test passed");
            }
            catch (Exception exception)
            {
                test.Log(Status.Fail, exception.ToString());
                throw;
            }
        }

        [Test, Order(3)]
        public void PlaceOrderTestMethod()
        {
            try
            {
                test = extent.CreateTest("PlaceOrderTestMethod").Info("Place order Test Started");
                PlaceOrder placeOrder = new PlaceOrder(driver);
                string cartHeader= placeOrder.BookOrder();
                test.Log(Status.Info, "Proceed to checkout");
                cartHeader.Contains("my shopping cart");
                test.Log(Status.Pass, "Test passed");
            }
            catch (Exception exception)
            {
                test.Log(Status.Fail, exception.ToString());
                throw;
            }
        }

        [Test, Order(4)]
        public void CheckoutCartTestMethod()
        {
            try
            {
                test = extent.CreateTest("CheckoutCartTestMethod").Info("Checkout from cart Test Started");
                Checkout checkout = new Checkout(driver);
                checkout.ChechOutCart();
                string cartUrl = "https://www.bookswagon.com/viewshoppingcart.aspx";
                Assert.AreEqual(cartUrl, driver.Url);
                test.Log(Status.Info, "Entered all the credentials");
                test.Log(Status.Pass, "Test passed");
            }
            catch (Exception exception)
            {
                test.Log(Status.Fail, exception.ToString());
                throw;
            }
        }

        [Test,Order(5)]
        public void LogoutTestMethod()
        {
            try
            {
                test = extent.CreateTest("PlaceOrderTestMethod").Info("Place order Test Started");
                Logout logout = new Logout(driver);
                logout.LogoutBookswagon();
                test.Log(Status.Pass, "Logout from Bookswagon");
            }
            catch(Exception exception)
            {
                test.Log(Status.Fail, exception.ToString());
            }
        }

        [Test]
        public void SendMailTestMethod()
        {
            try
            {
                Mail mail = new Mail();
                mail.SendMail(JsonData.data.subject,JsonData.data.contentBody);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        //Method to quit browser
        [OneTimeTearDown]
        public void ExtentClose()
        {
            // Closes all the connections to the extend reports
            extent.Flush();
            Thread.Sleep(1000);
            driver.Quit();
            test.Log(Status.Info, "Quits Chrome browser");
        }
    }
}
