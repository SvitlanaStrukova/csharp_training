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

        public ContactHelper SendEmail(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContacts(v);
            SendEmailtoContacts();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper RemoveFromModification(int v)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v);
            DeleteContactFromModification();
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper SendEmail()
        {
            manager.Navigator.GoToHomePage();
            SelectContacts();
            SendEmailtoContacts();
            manager.Navigator.OpenHomePage();
            return this;
        }



        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper DetailsOfContract(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])["+v+"]")).Click();
            return this;
        }

        public ContactHelper Print(int v)
        {
            manager.Navigator.GoToHomePage();
            DetailsOfContract(v);
            PrintContactDetails();
            manager.Navigator.OpenHomePage();
            return this;
        }


        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContacts(v);
            DeleteContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            SelectContacts();
            DeleteContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v);
            FillContactForm(newdata);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ModifyFromDetails(int v, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            DetailsOfContract(v);
            ModifyContactsDetails();
            FillContactForm(newdata);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper AddToGroup(int c, string g)
        {
            manager.Navigator.GoToHomePage();
            SelectContacts(c);
            SelectGroup(g);
            AddContactToGroup();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper AddToGroup(string g)
        {
            manager.Navigator.GoToHomePage();
            SelectContacts();
            SelectGroup(g);
            AddContactToGroup();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+v+"]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }


        public ContactHelper PrintContactDetails()
        {
            driver.FindElement(By.Name("print")).Click();
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

        public ContactHelper AddContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
            return this;
        }

        
        public ContactHelper SendEmailtoContacts()
        {
            driver.FindElement(By.CssSelector("input[type=\"button\"]")).Click();
            return this;
        }

        public ContactHelper SelectGroup(string v)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(v);
            return this;
        }

        public ContactHelper SelectContacts()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }

        public ContactHelper SelectContacts(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper DeleteContactFromModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }

        public ContactHelper ModifyContactsDetails()
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

    }
}
