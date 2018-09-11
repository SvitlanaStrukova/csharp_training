using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{


    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //prepare
            GroupData newData = new GroupData("fgd");
            newData.Footer = null;
            newData.Header = "dfgh";

            //action
            app.Groups.CreateIfNotExist("hhh");
            app.Groups.Modify("hhh", newData);
        }
    }
}
