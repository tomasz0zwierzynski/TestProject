using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WorkersTests
{
    [TestFixture]
    class SeleniumTest
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(@"C:\Users\Patrial Derivative\Documents\Programming\Visual Studio\AspNet\Workers\drivers");
        }

        [Test]
        public void ShowWorkersTest()
        {
            _driver.Navigate().GoToUrl("https://localhost:44331/");
            _driver.FindElement(By.Id("workers")).Click();
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[text()[contains(.,'Nowak')]]")));

                Assert.Pass();
            } catch ( NoSuchElementException ex )
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ShowPositionsTest()
        {
            _driver.Navigate().GoToUrl("https://localhost:44331/");
            _driver.FindElement(By.Id("positions")).Click();
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[text()[contains(.,'Kierownik2')]]")));

                Assert.Pass();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail();
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            _driver.Close();
        }
    }
}
