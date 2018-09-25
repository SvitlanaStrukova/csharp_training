using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //prepare
            ContactData newdata = new ContactData("jfswerf");
            newdata.Firstname = "fjlkhg";

            ContactData olddata = new ContactData("fdhgfdh");
            olddata.Firstname = "fgh";

            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            ContactData oldcontact = oldcontacts[i];
            app.Contacts.Modify(olddata.Firstname + " " + olddata.Lastname, newdata);

            Assert.AreEqual(oldcontacts.Count, app.Contacts.GetContactCount());

            List<ContactData> contacts = app.Contacts.GetContactsList();

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
            ContactData newdata = new ContactData("ghjhhh");
            newdata.Firstname = "fffffff";

            ContactData olddata = new ContactData("khjkjlk");
            olddata.Firstname = "dfgfdg";

            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            ContactData oldcontact = oldcontacts[i];

            app.Contacts.ModifyFromDetails(olddata.Firstname + " " + olddata.Lastname, newdata);
            Assert.AreEqual(oldcontacts.Count, app.Contacts.GetContactCount());
            List<ContactData> contacts = app.Contacts.GetContactsList();

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
