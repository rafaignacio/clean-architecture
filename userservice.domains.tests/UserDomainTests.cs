using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.rafaip.userservice.domains.Entities;

namespace com.rafaip.userservice.domains.tests
{
    [TestClass]
    public class UserDomainTests
    {
        [TestMethod]
        public void ShouldCreateSuccessfully()
        {
            Assert.IsNotNull(User.Create("teste@abc.com", "User", "123456"));
        }

        [TestMethod]
        public void ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => User.Create(null, null, null));
        }

        [TestMethod]
        public void ShouldValidatePassword()
        {
            var user = User.Create("teste@abc.com", "User", "123456");

            Assert.IsTrue(user.CheckPassword("123456"));
        }
    }
}
