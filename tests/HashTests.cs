using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaltedSecuredHashAlgorithm;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SaltedHashAlgorithmTests
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void GenerateSaltString_StringFixedLength()
        {
            // Act
            string saltString = Hash.GenerateSaltString();

            // Assert
            Assert.IsTrue(saltString.Length == Hash.LENGTH);
        }

        [TestMethod]
        public void GenerateSaltString_StringNotNull()
        {
            // Act
            string saltString = Hash.GenerateSaltString();

            // Assert
            Assert.IsNotNull(saltString);
        }

        [TestMethod]
        public void SaltPassword_StringNotNull()
        {
            // Arrange
            LogInfo logIn = new("User", "pass.word");

            // Act
            string saltPassword = Hash.SaltPassword(logIn);

            // Assert
            Assert.IsNotNull(saltPassword);
        }

        [TestMethod]
        public void SaltPassword_LongerThanSaltString()
        {
            // Arrange
            LogInfo logIn = new("User", "pass.word");

            // Act
            string saltPassword = Hash.SaltPassword(logIn);

            // Assert
            Assert.IsTrue(saltPassword.Length == (logIn.Password.Length + Hash.LENGTH));
        }

        [TestMethod]
        public void GenerateHashString_GeneratesStringNotNull()
        {
            // Arrange
            LogInfo logIn = new("User", "pass.word");
            MD5CryptoServiceProvider algorithm = new();

            // Act
            string hashedPass = Hash.GenerateHashString(algorithm, logIn.Password);

            // Assert
            Assert.IsNotNull(hashedPass);
        }

        [TestMethod]
        public void HashData_ReturnsListNotNull()
        {
            // Arrange
            List<LogInfo> list = new();
            list.Add(new LogInfo("user1", "pass"));
            list.Add(new LogInfo("user2", "pass"));
            list.Add(new LogInfo("user3", "pass"));

            // Act
            List<LogInfo> resultList = Hash.HashData(list);

            // Assert
            Assert.IsNotNull(resultList);
        }
    }
}
