using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Footer = GenerateRandomString(100),
                    Header = GenerateRandomString(100)
                });
            }

            return groups;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldgroups.Count+1,app.Groups.GetGroupCount());

            List<GroupData> groups = app.Groups.GetGroupList();
            oldgroups.Add(group);
            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldgroups, groups);
        }               
    } 
}
