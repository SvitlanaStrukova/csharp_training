using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //action
            app.Groups.CreateIfNotExist("fklj");

            List<GroupData> oldgroups = GroupData.GetAll();
            int i = app.Groups.FindIndexByName("fklj");
            GroupData toBeRemoved = oldgroups[i];
            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldgroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> groups = GroupData.GetAll();


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