using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(string name)
        {

            if (driver.FindElement(By.CssSelector("h1")).Text=="Group")
            {
                if (driver.FindElement(By.CssSelector("span.group")).Text == name)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (IsElementPresent(By.CssSelector("input[title=\"Select (" + name + ")")))
                {
                    return true;
                }
                return false;
            }
        }


        public HelperBase SelectElement(string name)
        {

            driver.FindElement(By.CssSelector("input[title=\"Select (" + name + ")")).Click();

            return this;
        }
    }

}