using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebUI.Pages
{
    class MainPage : BasePage
    {
        
        private static readonly By laptopsLocator = By.XPath("//a[text()='Laptops']");
        private static readonly By productLocator = By.XPath("//a[text()='Dell i7 8gb']");
       

        public MainPage(WebDriver driver) : base(driver)
        {
            return;
        }

        public MainPage GoToLaptops()
        {
            try
            {
                driver.FindElement(laptopsLocator).Click();
            }
            catch (StaleElementReferenceException exception)
            {
                driver.FindElement(laptopsLocator).Click();
            }
            
            return this;
        }

        public ProductPage GoToProductPage()
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitToLoad.Until(placeOrder => driver.FindElement(productLocator));
            try
            {
                driver.FindElement(productLocator).Click();
            }
            catch (StaleElementReferenceException exception)
            {
                driver.FindElement(productLocator).Click();
            }

            return new ProductPage(driver);
        }

        public ProductPage GoToLaptopPageScenario()
        {
            GoToLaptops();
            return GoToProductPage();
        }
    }
}
