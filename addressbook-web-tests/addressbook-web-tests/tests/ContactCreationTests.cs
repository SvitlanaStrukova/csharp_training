using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {

            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            ContactData contact = new ContactData("gjfgj");
            contact.Firstname = "fghjfghj";
            app.Contacts.Create(contact);
            List<ContactData> contacts = app.Contacts.GetContactsList();

            oldcontacts.Add(contact);
            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);

        }       
    }
}
