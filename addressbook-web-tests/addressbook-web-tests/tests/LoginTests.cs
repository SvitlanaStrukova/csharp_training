using System;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // prepare
            AccountData account = new AccountData("admin", "secret");

            //action

            app.auth.Logout();
            app.auth.Login(account);

            //verification
            Assert.IsTrue(app.auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // prepare
            AccountData account = new AccountData("admin", "123456");

            //action

            app.auth.Logout();
            app.auth.Login(account);

            //verification
            Assert.IsFalse(app.auth.IsLoggedIn(account));
        }
    }
}
