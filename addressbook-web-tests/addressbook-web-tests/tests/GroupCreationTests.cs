using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("fgd");
            group.Footer = "dhsdfg";
            group.Header = "dfgh";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldgroups.Count+1,app.Groups.GetGroupCount());

            List<GroupData> groups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldgroups, groups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Footer = "";
            group.Header = "";
            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldgroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> groups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldgroups.Count, groups.Count);
        }


        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("hj'ghgh");
            group.Footer = "";
            group.Header = "";
            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldgroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> groups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldgroups.Count, groups.Count);
        }
    } 
}
