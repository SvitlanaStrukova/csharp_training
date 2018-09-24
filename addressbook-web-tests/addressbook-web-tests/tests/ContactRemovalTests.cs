using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {



        [Test]
        public void ContactRemovalTest()
        {

            ContactData olddata = new ContactData("iiiiii");
            olddata.Firstname = "iiiiiii";

            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);

            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            app.Contacts.Remove(olddata.Firstname + " " + olddata.Lastname);

            List<ContactData> contacts = app.Contacts.GetContactsList();

            oldcontacts.RemoveAt(i);
            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);
                       
        }

        [Test]
        public void ContactRemovalFromModificationTest()
        {
            //prepare
            ContactData olddata = new ContactData("hjfgh");
            olddata.Firstname = "gfdxgh";
            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname,olddata.Lastname, olddata);
            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            app.Contacts.RemoveFromModification(olddata.Firstname + " " + olddata.Lastname);

            List<ContactData> contacts = app.Contacts.GetContactsList();

            oldcontacts.RemoveAt(i);
            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);

        }

        [Test]
        public void ContactRemovalAllTest()
        {
            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            app.Contacts.Remove();
            oldcontacts.Sort();
            oldcontacts.RemoveRange(0,oldcontacts.Count-1);

            List<ContactData> contacts = app.Contacts.GetContactsList();
            oldcontacts.Sort();
            contacts.Sort();
            Assert.AreEqual(oldcontacts, contacts);


        }
    }
}
