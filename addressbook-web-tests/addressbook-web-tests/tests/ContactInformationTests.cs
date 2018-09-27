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
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable= app.Contacts.GetContactInformationFromTable("fffffffffff ffffffff");
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm("ffffffff fffffffffff");

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }


        [Test]
        public void TestContactInformationfromDetails()
        {

            String fromTable = app.Contacts.GetContactInformationFromDetails("fghjfghj gjfgj");
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm("fghjfghj gjfgj");
            String fromFormAggr=app.Contacts.GetAggreagtedInformationFromContact(fromForm);
            Assert.AreEqual(fromTable, fromFormAggr);

        }
    }
}
