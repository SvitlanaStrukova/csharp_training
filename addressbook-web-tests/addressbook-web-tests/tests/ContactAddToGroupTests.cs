using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAddToGroupTests : AuthTestBase
    {
        [Test]
        public void ContactAddToGroupTest()
        {

            ContactData contact = new ContactData("ghjhhh", "fffffff");
            app.Contacts.CreateIfNotExist(contact.Firstname, contact.Lastname, contact);
            app.Groups.CreateIfNotExist("yiuyi");
            int i = app.Groups.FindIndexByName("yiuyi");
            GroupData group = GroupData.GetAll()[i];


            List<ContactData> oldList = group.GetContacts();

            app.Contacts.AddToGroup(contact,group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }

        [Test]
        public void FirstContactAddToGroupTest()
        {
            app.Groups.CreateIfNotExist("gfhgf");
            int i = app.Groups.FindIndexByName("gfhgf");
            GroupData group = GroupData.GetAll()[i];
            
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList,newList);

        }

       [Test]
        public void ContactAddAllToGroupTest()
        {
            app.Groups.CreateIfNotExist("fgfg");
            int i = app.Groups.FindIndexByName("fgfg");
            GroupData group = GroupData.GetAll()[i];
             List<ContactData> oldList = group.GetContacts();

             app.Contacts.AddToGroup(group);

             oldList = ContactData.GetAll();
             List<ContactData> newList = group.GetContacts();

             Assert.AreEqual(oldList, newList);
        }

       [Test]
        public void ContactAddToGroupUITest()
        {
            ContactData contact = new ContactData("ghjhhh", "fffffff");
            GroupData group = new GroupData("khjkjlk");

            app.Contacts.CreateIfNotExist(contact.Firstname, contact.Lastname, contact);
            app.Groups.CreateIfNotExist(group.Name);

            int i = app.Groups.FindIndexByName(group.Name);
            GroupData dbGroup = GroupData.GetAll()[i];

            app.Contacts.AddToGroup(contact, group);

            List<ContactData> contactFromUI = app.Contacts.GetContactsForGroup(group);
            List<ContactData> contactFromDB = dbGroup.GetContacts();

            contactFromUI.Sort();
            contactFromDB.Sort();


            Assert.AreEqual(contactFromUI, contactFromDB);


        }

    }
}
