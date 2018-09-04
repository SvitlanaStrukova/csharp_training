using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        public ContactHelper RemoveContact(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.Name("Delete")).Click();
            return this;
        }

        public ContactHelper AddContactToGroup(int c, int g)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(c);
            SelectGroup(g);
            AddToGroup();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper AddToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
            return this;
        }

        public ContactHelper SelectGroup(int v)
        {

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

    }
}
