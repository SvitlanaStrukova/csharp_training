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
            app.Contacts.AddToGroup(1,"d");
        }

        [Test]
        public void ContactAddAllToGroupTest()
        {
            app.Contacts.AddToGroup("d");
        }


    }
}
