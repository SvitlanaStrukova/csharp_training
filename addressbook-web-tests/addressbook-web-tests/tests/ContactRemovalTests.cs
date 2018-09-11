using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {



        [Test]
        public void ContactRemovalTest()
        {
            ContactData olddata = new ContactData("khjkjlk");
            olddata.Firstname = "dfgfdg";
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            app.Contacts.Remove(olddata.Firstname + " " + olddata.Lastname);
        }

        [Test]
        public void ContactRemovalFromModificationTest()
        {
            //prepare
            ContactData olddata = new ContactData("hjfgh");
            olddata.Firstname = "gfdxgh";
            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname,olddata.Lastname, olddata);
            app.Contacts.RemoveFromModification(olddata.Firstname + " " + olddata.Lastname);
            
        }

        [Test]
        public void ContactRemovalAllTest()
        {
            app.Contacts.Remove();
        }
    }
}
