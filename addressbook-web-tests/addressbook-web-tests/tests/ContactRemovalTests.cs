﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(2);
        }

        [Test]
        public void ContactRemovalFromModificationTest()
        {
            app.Contacts.RemoveFromModification(2);
        }

        [Test]
        public void ContactRemovalAllTest()
        {
            app.Contacts.Remove();
        }
    }
}
