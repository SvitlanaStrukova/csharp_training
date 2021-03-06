﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        public ContactHelper EnterValueForSearchString(string v)
        {
            manager.Navigator.GoToHomePage();
            Type(By.Name("searchstring"), v);
            return this;
        }

        public ContactHelper SendEmail(string v)
        {
            manager.Navigator.GoToHomePage();
            SelectElement(v);
            SendEmailtoContacts();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public String GetContactInformationFromDetails(string v)
        {
            manager.Navigator.GoToHomePage();
            DetailsOfContract(v);
            return driver.FindElement(By.Id("content")).Text;
        }

        public string GetAggreagtedInformationFromContact(ContactData data)
        {
            return (data.Firstname + " " + data.Lastname + "\r\n"+ AddData("",data.Address) + "\r\n" +AddData("H: ", data.Home)
                +AddData("M: ", data.Mobile)+ AddData("W: ", data.Work)+AddData("\r\n", data.Emails)).Trim();
        }

        public string AddData(string prefix, string word)
        {
            if (word != "" && word!=null)
            {
                return prefix + word + "\r\n";
            }
            else
            {
                return "";
            }
        }

        public ContactData GetContactInformationFromEditForm(string name)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(name);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileHome = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            
            return new ContactData(lastname, firstname) { Address = address, Home = homePhone, Mobile = mobileHome,
                Work = workPhone, Email=email, Email2=email2, Email3=email3 };


        }


        public ContactData GetContactInformationFromTable(string name)
        {
            int i = FindIndexByName(name);
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells=driver.FindElements(By.Name("entry"))[i].FindElements(By.TagName("td"));
            string firstname = cells[1].Text;
            string lastname = cells[2].Text;
            string address = cells[3].Text;
            string emails= cells[4].Text; ;
            string allPhones = cells[5].Text;
            return new ContactData(lastname, firstname) { Address = address, allPhones = allPhones, emails = emails};

        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {

            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElements(By.TagName("td"))[1].Text, element.FindElements(By.TagName("td"))[2].Text)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
            }

            return new List<ContactData>(contactCache);
        }


        public List<ContactData> GetContactsForGroup(GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            ChooseGroupFilter(group.Name);
            return GetContactsList();
        }


        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper RemoveFromModification(string v)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v);
            DeleteContactFromModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromModification(ContactData v)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v.Firstname + " " + v.Lastname);
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

        public ContactHelper Remove(ContactData v)
        {
            manager.Navigator.GoToHomePage();
            SelectElement(v.Firstname + " " + v.Lastname);
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

        public ContactHelper Modify(ContactData olddata, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(olddata.Firstname + " " + olddata.Lastname).
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


        public ContactHelper ModifyFromDetails(ContactData olddata, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            DetailsOfContract(olddata.Firstname + " " + olddata.Lastname);
            ModifyContactsDetails();
            FillContactForm(newdata);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper AddToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectElement(contact.Firstname+" "+ contact.Lastname);
            SelectGroup(group.Name);
            AddContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ChooseGroupFilter(group.Name);
            SelectElement(contact.Firstname + " " + contact.Lastname);
            RemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromGroup(GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ChooseGroupFilter(group.Name);
            SelectContacts();
            RemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            return this;
        }


        public ContactHelper ChooseGroupFilter(string group)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(group);
            return this;
        }

        public ContactHelper AddToGroup(GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContacts();
            SelectGroup(group.Name);
            AddContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                            Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigator.GoToHomePage();
            return this;
        }




        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(string v)
        {

            driver.FindElement(By.CssSelector("a[href=\"edit.php?id=" + driver.FindElement(By.CssSelector("input[title=\"Select (" + v + ")"))
                .GetAttribute("id"))).FindElement(By.CssSelector("img[title=\"Edit")).Click();

            return this;
        }

        public int FindIndexByName(string v)
        {
            int i = 0;
            List<ContactData> contacts = ContactData.GetAll();
            foreach (ContactData element in contacts)
            {
                if (element.Lastname + " " + element.Firstname == v)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return -1;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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

        public ContactHelper RemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text=driver.FindElement(By.TagName("label")).Text;
            Match m=new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
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
            contactCache = null;
            return this;
        }

        public ContactHelper DeleteContactFromModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            contactCache = null;
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
