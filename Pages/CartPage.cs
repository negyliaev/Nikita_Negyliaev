using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using WebUI.Entities;

namespace WebUI.Pages
{
    class CartPage : BasePage
    {
        private static By placeOrderLocator = By.XPath("//button[text()='Place Order']");
        private static By nameLocator = By.XPath("//*[@id=\"name\"]");
        private static By countryLocator = By.XPath("//*[@id=\"country\"]");
        private static By cityLocator = By.XPath("//*[@id=\"city\"]");
        private static By creditCardLocator = By.XPath("//*[@id=\"card\"]");
        private static By monthLocator = By.XPath("//*[@id=\"month\"]");
        private static By yearLocator = By.XPath("//*[@id=\"year\"]");
        private static By purchaseLocator = By.XPath("//*[@id=\"orderModal\"]/div/div/div[3]/button[2]");
        private static By confirmationPopUpLocator = By.XPath("//h2[text()='Thank you for your purchase!']");


        //private static By cartLocator = By.XPath("//*[@id=\"cartur\"]");

        public CartPage(WebDriver driver) : base(driver) 
        {
            return;
        }


        public CartPage PlaceOrder(){
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(placeOrder => driver.FindElement(placeOrderLocator));
            driver.FindElement(placeOrderLocator).Click();
            return this;
        }

        public CartPage FillForm(OrderEntity order)
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(el => driver.FindElement(nameLocator));
            driver.FindElement(nameLocator).SendKeys(order.Name);
            driver.FindElement(countryLocator).SendKeys(order.Country);
            driver.FindElement(cityLocator).SendKeys(order.City);
            driver.FindElement(creditCardLocator).SendKeys(order.CreditCard);
            driver.FindElement(monthLocator).SendKeys(order.Month);
            driver.FindElement(yearLocator).SendKeys(order.Year);
           
            return this;
        }

        public CartPage Purchase()
        {
            driver.FindElement(purchaseLocator).Click();
            return this;
        }

        public bool IfPopUp(string name, string creditCard)
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitToLoad.Until(popUp => driver.FindElement(confirmationPopUpLocator).Enabled);
            try
            {
                By nameLocator = By.XPath("//p[text()='Name: " + name + "']");
                By cardLocator = By.XPath("//p[text()='Card Number: " + creditCard + "']");


                if (driver.FindElement(confirmationPopUpLocator).Enabled && driver.FindElement(nameLocator).Enabled && driver.FindElement(cardLocator).Enabled)
                    return true;
                return false;
            }
            catch (NoSuchElementException exception)
            {
                return false;
            }
        }

        public bool PurchaseWithDetailsScenario(OrderEntity order)
        {
            PlaceOrder();
            Thread.Sleep(200);
            FillForm(order);
            Purchase();
            return IfPopUp(order.Name, order.CreditCard);
        }

    }
}
