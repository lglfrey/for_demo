using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ООО_Техносервис_Test
{
    [TestClass]
    public class UnitTest1
    {
        private AuthService _authService;

        [TestInitialize]
        public void Setup()
        {
            _authService = new AuthService();
        }
        [TestMethod]
        public void Authentificate_Valid_Return_True()
        {
            string login = "user1";
            string password = "password1";

            bool result = _authService.Authntificate(login, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Authentificate_Valid_Return_False()
        {
            string login = "user123";
            string password = "password1";

            bool result = _authService.Authntificate(login, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Authentificate_With_Empty_Login_Return_False()
        {
            string login = "";
            string password = "password1";

            bool result = _authService.Authntificate(login, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Authentificate_With_Empty_Password_Return_False()
        {
            string login = "user1";
            string password = "";

            bool result = _authService.Authntificate(login, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Authentificate_With_Null_Password_Return_False()
        {
            string login = "user1";
            string password = null;

            bool result = _authService.Authntificate(login, password);

            Assert.IsFalse(result);
        }
    }
}
