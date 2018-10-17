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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) :
            base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public int FindIndexByName(string v)
        {
            int i = 0;
            List<GroupData> groups = GetGroupList();
            foreach (GroupData element in groups)
            {
                if (element.Name == v)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return -1 ;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {

            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                      groupCache.Add(new GroupData(element.Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")});
                }

            }
            return new List<GroupData>(groupCache);
        }


        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count; 
        }


        public GroupHelper CreateIfNotExist(string h)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(h))
            {
                GroupData data = new GroupData(h);
                Create(data);
            }
            return this;
        }

        public GroupHelper Remove(string index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectElement(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectElement(Convert.ToInt32(group.Id));
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(string index, GroupData newData)
        {

            manager.Navigator.GoToGroupsPage();
            SelectElement(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(GroupData oldData, GroupData newData)
        {

            manager.Navigator.GoToGroupsPage();
            SelectElement(Convert.ToInt32(oldData.Id));
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData data)
        {

            Type(By.Name("group_name"), data.Name);
            Type(By.Name("group_header"), data.Header);
            Type(By.Name("group_footer"), data.Footer);
            return this;
        }

       

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

    }
}
