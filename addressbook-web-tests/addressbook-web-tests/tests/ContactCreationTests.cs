using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {


        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(100)
                });
            }

            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider") ]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldcontacts = app.Contacts.GetContactsList();
            app.Contacts.Create(contact);
            List<ContactData> contacts = app.Contacts.GetContactsList();



            Assert.AreEqual(oldcontacts.Count + 1, app.Contacts.GetContactCount());

            oldcontacts.Add(contact);
            oldcontacts.Sort();
            contacts.Sort();

            Assert.AreEqual(oldcontacts, contacts);

        }       
    }
}
