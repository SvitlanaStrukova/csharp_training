using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    class ContactSearchTests : AuthTestBase
    {
        [Test]
        public void ContactTestSearch()
        {
            app.Contacts.EnterValueForSearchString("fs");

            Assert.AreEqual(app.Contacts.GetNumberOfSearchResults(), app.Contacts.GetContactsList().Count);
        }
    }
}
