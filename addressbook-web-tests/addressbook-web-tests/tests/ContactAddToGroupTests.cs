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
            app.Contacts.AddToGroup(1, "fgd");
        }

        [Test]
        public void ContactAddAllToGroupTest()
        {
            app.Contacts.AddToGroup("");
        }


    }
}
