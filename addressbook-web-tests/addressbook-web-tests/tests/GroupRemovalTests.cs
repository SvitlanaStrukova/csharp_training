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

              List<GroupData> groups = app.Groups.GetGroupList();

              oldgroups.RemoveAt(i);

              Assert.AreEqual(oldgroups,groups);
        }

    }
}