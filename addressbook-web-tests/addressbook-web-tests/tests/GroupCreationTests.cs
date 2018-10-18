using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));


        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {

            List<GroupData> oldgroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldgroups.Count+1,app.Groups.GetGroupCount());

            List<GroupData> groups = GroupData.GetAll();
            oldgroups.Add(group);
            oldgroups.Sort();
            groups.Sort();
            Assert.AreEqual(oldgroups, groups);
        }


        [Test]
         public void TestDBConnectivity()
         {
             DateTime start = DateTime.Now;
             List<GroupData> fromUI = app.Groups.GetGroupList();
             DateTime end = DateTime.Now;
             System.Console.Out.WriteLine(end.Subtract(start));

             start = DateTime.Now;
             List<GroupData> fromDB = GroupData.GetAll();
             end = DateTime.Now;
             System.Console.Out.WriteLine(end.Subtract(start));
         }
    }
}
