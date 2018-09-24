using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAddToGroupTests : AuthTestBase
    {
        [Test]
        public void ContactAddToGroupTest()
        {
            app.Contacts.AddToGroup("fdhgfdh fgh", "fgd");
        }

        [Test]
        public void ContactAddAllToGroupTest()
        {
            app.Contacts.AddToGroup("fgd");
        }


    }
}
