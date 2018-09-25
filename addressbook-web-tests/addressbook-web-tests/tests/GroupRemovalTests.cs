using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
              //action
              app.Groups.CreateIfNotExist("fklj");

              List<GroupData> oldgroups = app.Groups.GetGroupList();
              int i = app.Groups.FindIndexByName("fklj");
              app.Groups.Remove("fklj");

            Assert.AreEqual(oldgroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> groups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldgroups[i];
            oldgroups.RemoveAt(i);

            oldgroups.Sort();
            groups.Sort();

            Assert.AreEqual(oldgroups,groups);

            foreach (GroupData group in groups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

    }
}