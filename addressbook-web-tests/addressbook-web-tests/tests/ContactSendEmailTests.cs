using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactSendEmailTests : TestBase
    {
        [Test]
        public void ContactSendEmailTest()
        {
            app.Contacts.SendEmail(1);
        }

        [Test]
        public void ContactSendEmailForAllTest()
        {
            app.Contacts.SendEmail();
        }
    }
}
