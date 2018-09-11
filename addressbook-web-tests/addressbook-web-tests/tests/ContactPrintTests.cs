using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactPrintTests : AuthTestBase
    {
        [Test]
        public void ContactPrintTest()
        {
            app.Contacts.Print("dfjg dsfhgj");
        }

       
    }
}
