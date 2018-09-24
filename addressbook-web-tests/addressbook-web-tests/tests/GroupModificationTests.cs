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
            GroupData newData = new GroupData("fklj");
            newData.Footer = null;
            newData.Header = "dsdg";

            //action
            app.Groups.CreateIfNotExist("ffff");
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            int i = app.Groups.FindIndexByName("ffff");
            app.Groups.Modify("fgd", newData);

            List<GroupData> groups = app.Groups.GetGroupList();

            oldgroups[i].Name=newData.Name;
            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldgroups, groups);

        }
    }
}
