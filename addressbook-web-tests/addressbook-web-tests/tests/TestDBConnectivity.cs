using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class DBConnectivityTests
    {


        [Test]
        public void DBConnectivityRelationsTest()
        {
            foreach (ContactData contacts in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contacts);
            }
        }
    }
}
