using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using WebUI.Pages;
using WebUI.Entities;

namespace WebUI
{
    public class Scenario
    {
        private WebDriver driver;
        private static readonly string siteUrl = "https://www.demoblaze.com/";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(Path.GetFullPath("driver"));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(siteUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }

        [Test]
        public void PurchaseLaptopScenario()
        {
            LoginPage loginPage = new LoginPage(driver);
            bool scenarioResult = loginPage.LoginAsScenario(new UserStorage("userqwerty", "passqwerty"))
                .GoToLaptopPageScenario()
                .AddLaptopToCartScenario()
                .PurchaseWithDetailsScenario(new OrderEntity("myname", "mycountry", "mycity", "12345678", "May", "2022"));
            

            Assert.AreEqual(true, scenarioResult);
        }

        [OneTimeTearDownAttribute]
        public void CloseDriver()
        {
            driver.Close();
        }


    }
}
