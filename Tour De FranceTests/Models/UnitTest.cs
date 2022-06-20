using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tour_De_France.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tour_De_France.Pages.LogIn;


namespace Tour_De_France.Models.Tests
{
    [TestClass]
    public class UnitTest
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        private static IWebDriver _driver;
        //private string driverUrl;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver (DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestWithSelenium()
        {
            string url = "https://localhost:44324";

            _driver.Navigate().GoToUrl(url);

            Thread.Sleep(3000);

            IWebElement loginElement0 = _driver.FindElement(By.Id("knap-til-login"));
            loginElement0.Click();

            Thread.Sleep(4000);

            IWebElement loginElement = _driver.FindElement(By.Id("login-name"));
            loginElement.SendKeys("chris");

            Thread.Sleep(3000);

            IWebElement loginElement2 = _driver.FindElement(By.Id("login-password"));
            loginElement2.SendKeys("chris");

            Thread.Sleep(3000);

            IWebElement buttonElement = _driver.FindElement(By.Id("login-knap"));
            buttonElement.Click();

            Thread.Sleep(5000);

            IWebElement vipElement = _driver.FindElement(By.Id("vip"));
            vipElement.Click();

            Thread.Sleep(5000);

            IWebElement vipElementCart = _driver.FindElement(By.Id("vip-cart"));
            vipElementCart.Click();

            Thread.Sleep(5000);

            IWebElement vipElementChampagne = _driver.FindElement(By.Id("vip-champagne"));
            vipElementChampagne.Click();

            Thread.Sleep(5000);

            IWebElement vipElementCount = _driver.FindElement(By.Id("vip-count"));
            vipElementCount.SendKeys(Keys.ArrowRight + Keys.Backspace + "1");

            Thread.Sleep(5000);

            IWebElement vipElementBestil = _driver.FindElement(By.Id("vip-bestil"));
            vipElementBestil.Click();

            Thread.Sleep(5000);

            IWebElement indexElement = _driver.FindElement(By.Id("homepage"));
            indexElement.Click();

            Thread.Sleep(5000);

            _driver.Quit();
        }
    }
}