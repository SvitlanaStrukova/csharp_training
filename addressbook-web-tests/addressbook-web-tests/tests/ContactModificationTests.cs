using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newdata = new ContactData("fdhgfdh");
            newdata.Firstname = "fgh";
            app.Contacts.Modify(2, newdata);
        }

        [Test]
        public void ContactModificationFromDetailsTest()
        {
            ContactData newdata = new ContactData("gggggg");
            newdata.Firstname = "ggggg";
            app.Contacts.ModifyFromDetails(2, newdata);
        }
    }
}
