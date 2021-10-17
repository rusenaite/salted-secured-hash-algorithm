using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaltedSecuredHashAlgorithm;
using System.Collections.Generic;
using System.IO;

namespace SaltedHashAlgorithmTests
{
    [TestClass]
    public class FileWriterTests
    {
        [TestMethod]
        public void WriteToTxt_FileCreated()
        {
            // Arrange
            string path = "C:/Users/raust/source/repos/SaltedSecuredHashAlgorithm/hashed_log_info.txt";

            List<LogInfo> list = new();
            list.Add(new LogInfo("user1", "pass"));
            list.Add(new LogInfo("user2", "pass"));
            list.Add(new LogInfo("user3", "pass"));

            // Act
            FileWriter.WriteToTxt(list);

            // Assert
            Assert.IsTrue(File.Exists(path));
        }
    }
}