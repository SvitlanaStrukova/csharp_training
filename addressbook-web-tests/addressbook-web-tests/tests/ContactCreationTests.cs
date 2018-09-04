using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.InitContactCreation();
            ContactData contact = new ContactData("fffff");
            contact.Firstname = "dddd";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.GoToHomePage();
            app.auth.Logout();
        }       
    }
}
