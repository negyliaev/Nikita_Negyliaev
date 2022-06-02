using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebUI.Entities;

namespace WebUI.Pages
{
    class LoginPage : BasePage
    {
        private static readonly By openLoginFormLocator = By.XPath("//*[@id=\"login2\"]");

        private static readonly By usernameLocator = By.XPath("//*[@id=\"loginusername\"]");
        private static readonly By passwordLocator = By.XPath("//*[@id=\"loginpassword\"]");
        private static readonly By submitButtonLocator = By.XPath("//*[@id=\"logInModal\"]/div/div/div[3]/button[2]");

        public LoginPage(WebDriver driver) : base(driver)
        {
            return;
        }

        public LoginPage OpenLoginForm()
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitToLoad.Until(el => driver.FindElement(openLoginFormLocator));
            driver.FindElement(openLoginFormLocator).Click();
            Thread.Sleep(50);
            return this;
        }

        public LoginPage PutUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public LoginPage PutPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public MainPage Submit()
        {
            driver.FindElement(submitButtonLocator).Click();
            return new MainPage(driver);
        }

        public MainPage LoginAs(string username, string password)
        {
            OpenLoginForm();
            Thread.Sleep(50);
            PutUsername(username);
            PutPassword(password);
            return Submit();
        }

        public MainPage LoginAsScenario(UserStorage user)
        {
            return LoginAs(user.Username, user.Password);
        }

    }
}
