using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAddToGroupTests : TestBase
    {
        [Test]
        public void ContactAddToGroupTest()
        {
            app.Contacts.AddContactToGroup(1,2);
            app.auth.Logout();
        }
    }
}
