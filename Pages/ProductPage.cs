using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebUI.Pages
{
    internal class ProductPage : BasePage   
    {
        private static By addToCartLocator = By.XPath("//*[@id=\"tbodyid\"]/div[2]/div/a");
        private static By cartLocator = By.XPath("//*[@id=\"cartur\"]");

        public ProductPage(WebDriver driver) : base(driver)
        {
            return;
        }

        public ProductPage AddItemToCart()
        {
            //WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //waitToLoad.Until(e => driver.FindElement(addToCartLocator));
            driver.FindElement(addToCartLocator).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public CartPage GoToCart()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/cart.html");
            return new CartPage(driver);
        }

        public CartPage AddLaptopToCartScenario()
        {
            return GoToCart();
        }

    }
}
