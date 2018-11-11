using com.rafaip.userservice.domains.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.rafaip.userservice.domains.tests
{
    [TestClass]
    public class PasswordTest
    {
        [TestMethod]
        public void ShouldCreatePassword()
        {
            var output = PasswordVO.Create("123456");

            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void ShouldMatchPassword()
        {
            var p1 = PasswordVO.Create("123456");
            var p2 = (PasswordVO)"123456";

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void ShouldCreateFromBase64()
        {
            var p1 = PasswordVO.Create("123456");
            var p2 = PasswordVO.Create(p1);

            Assert.AreEqual(p1, p2);
        }
    }
}