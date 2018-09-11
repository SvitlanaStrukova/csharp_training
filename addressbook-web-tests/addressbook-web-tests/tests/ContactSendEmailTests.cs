using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactSendEmailTests : AuthTestBase
    {
        [Test]
        public void ContactSendEmailTest()
        {
            app.Contacts.SendEmail("fdhgfdh fgh");
        }

        [Test]
        public void ContactSendEmailForAllTest()
        {
            app.Contacts.SendEmail();
        }
    }
}
