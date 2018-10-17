using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactTestBase:AuthTestBase
    {
        [TearDown]
        public void CompareContactsUIDB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = app.Contacts.GetContactsList();
                List<ContactData> fromDB = app.Contacts.GetAll();
                fromUI.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromUI, fromDB);
            }
        
        }
    }
}
