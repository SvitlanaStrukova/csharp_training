using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {



        [Test]
        public void ContactRemovalTest()
        {

            ContactData olddata = new ContactData("iiiiii", "iiiiiii");


            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);

            List<ContactData> oldcontacts = app.Contacts.GetAll(); 
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            ContactData toBeRemoved = oldcontacts[i];

            app.Contacts.Remove(toBeRemoved);
            Assert.AreEqual(oldcontacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> contacts = app.Contacts.GetAll();

            oldcontacts.RemoveAt(i);
            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);

            foreach (ContactData contact in contacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void ContactRemovalFromModificationTest()
        {
            //prepare
            ContactData olddata = new ContactData("hjfgh", "gfdxgh");

            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname,olddata.Lastname, olddata);
            List<ContactData> oldcontacts = app.Contacts.GetAll();
            int i = app.Contacts.FindIndexByName(olddata.Lastname + " " + olddata.Firstname);
            ContactData toBeRemoved = oldcontacts[i];

            app.Contacts.RemoveFromModification(toBeRemoved);

            Assert.AreEqual(oldcontacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> contacts = app.Contacts.GetAll();
            Console.Write(i);

            oldcontacts.RemoveAt(i);
            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);

            foreach (ContactData contact in contacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void ContactRemovalAllTest()
        {
            List<ContactData> oldcontacts = app.Contacts.GetAll();
            app.Contacts.Remove();
            oldcontacts.Sort();
            oldcontacts.RemoveRange(0,oldcontacts.Count);

            List<ContactData> contacts = app.Contacts.GetAll();
            oldcontacts.Sort();
            contacts.Sort();
            Assert.AreEqual(oldcontacts, contacts);


        }
    }
}
