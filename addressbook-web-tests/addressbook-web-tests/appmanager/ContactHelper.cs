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

        public ContactHelper SendEmail(string v)
        {
            manager.Navigator.GoToHomePage();
            SelectElement(v);
            SendEmailtoContacts();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper RemoveFromModification(string v)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v);
            DeleteContactFromModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper CreateIfNotExist(string v, string d, ContactData olddata)
        {
            if (!IsElementPresent(v+" "+d))
            {
                Create(olddata);
            }
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


        public ContactHelper Print(string v)
        {
            manager.Navigator.GoToHomePage();
            DetailsOfContract(v);
            PrintContactDetails();
            manager.Navigator.OpenHomePage();
            return this;
        }


        public ContactHelper Remove(string v)
        {
            manager.Navigator.GoToHomePage();
            SelectElement(v);
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

        public ContactHelper Modify(string v, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v).
            FillContactForm(newdata);            
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper ModifyFromDetails(string v, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            DetailsOfContract(v);
            ModifyContactsDetails();
            FillContactForm(newdata);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper AddToGroup(string c, string g)
        {
            manager.Navigator.GoToHomePage();
            SelectElement(c);
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

        public ContactHelper InitContactModification(string v)
        {

            driver.FindElement(By.CssSelector("a[href=\"edit.php?id=" + driver.FindElement(By.CssSelector("input[title=\"Select (" + v + ")"))
                .GetAttribute("id"))).FindElement(By.CssSelector("img[title=\"Edit")).Click();

            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }


        public ContactHelper PrintContactDetails()
        {
            driver.FindElement(By.Name("print")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
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

        public ContactHelper DetailsOfContract(string name)
        {
            driver.FindElement(By.CssSelector("a[href=\"view.php?id="+driver.FindElement(By.CssSelector("input[title=\"Select (" + name + ")"))
                .GetAttribute("id"))).FindElement(By.CssSelector("img[title=\"Details")).Click();


            return this;
        }

                
    }
}
