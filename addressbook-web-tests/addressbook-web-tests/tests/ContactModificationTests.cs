using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //prepare
            ContactData newdata = new ContactData("jfswerf");
            newdata.Firstname = "fjlkhg";

            ContactData olddata = new ContactData("fdhgfdh");
            olddata.Firstname = "fgh";

            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            app.Contacts.Modify(olddata.Firstname + " " + olddata.Lastname, newdata);
        }


        [Test]
        public void ContactModificationFromDetailsTest()
        {
            //prepare
            ContactData newdata = new ContactData("ghjhhh");
            newdata.Firstname = "fffffff";

            ContactData olddata = new ContactData("khjkjlk");
            olddata.Firstname = "dfgfdg";

            //action
            app.Contacts.CreateIfNotExist(olddata.Firstname, olddata.Lastname, olddata);
            app.Contacts.ModifyFromDetails(olddata.Firstname + " " + olddata.Lastname, newdata);            
        }
    }
}
