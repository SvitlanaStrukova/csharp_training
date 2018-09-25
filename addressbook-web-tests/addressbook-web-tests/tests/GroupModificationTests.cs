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
            GroupData olddata = oldgroups[i];
            app.Groups.Modify("ffff", newData);

            Assert.AreEqual(oldgroups.Count, app.Groups.GetGroupCount());

            List<GroupData> groups = app.Groups.GetGroupList();

            oldgroups[i].Name=newData.Name;

            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(groups, oldgroups);

            foreach (GroupData group in groups)
            {
                if(group.Id== olddata.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
