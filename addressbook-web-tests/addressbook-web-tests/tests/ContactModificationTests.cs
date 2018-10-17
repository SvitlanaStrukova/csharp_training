using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //prepare
            ContactData olddata = new ContactData("jfswerf", "fjlkhg");


            ContactData newdata = new ContactData("fdhgfdh", "fgh");


            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            List<ContactData> oldcontacts = app.Contacts.GetAll();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            ContactData oldcontact = oldcontacts[i];
            app.Contacts.Modify(oldcontact, newdata);

            Assert.AreEqual(oldcontacts.Count, app.Contacts.GetContactCount());

            List<ContactData> contacts = app.Contacts.GetAll();

            oldcontacts[i].Firstname = newdata.Firstname;
            oldcontacts[i].Lastname = newdata.Lastname;

            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);

            foreach (ContactData contact in contacts)
            {
                if (contact.Id == oldcontact.Id)
                {
                    Assert.AreEqual(newdata.Lastname+ newdata.Firstname, contact.Lastname+contact.Firstname);
                }
            }
        }


        [Test]
        public void ContactModificationFromDetailsTest()
        {
            //prepare
            ContactData olddata = new ContactData("ghjhhh", "fffffff");
            ContactData newdata = new ContactData("khjkjlk", "dfgfdg");

            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            List<ContactData> oldcontacts = app.Contacts.GetAll();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            ContactData oldcontact = oldcontacts[i];

            app.Contacts.ModifyFromDetails(oldcontact, newdata);
            Assert.AreEqual(oldcontacts.Count, app.Contacts.GetContactCount());
            List<ContactData> contacts = app.Contacts.GetAll();

            oldcontacts[i].Firstname = newdata.Firstname;
            oldcontacts[i].Lastname = newdata.Lastname;

            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);
            foreach (ContactData contact in contacts)
            {
                if (contact.Id == oldcontact.Id)
                {
                    Assert.AreEqual(newdata.Lastname + newdata.Firstname, contact.Lastname + contact.Firstname);
                }
            }
        }
    }
}
