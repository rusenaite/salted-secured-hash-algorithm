using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaltedSecuredHashAlgorithm;
using System.Collections.Generic;
using System.IO;

namespace SaltedHashAlgorithmTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void ReadTxtFile_FileExists()
        {
            // Arrange
            string fileName = Program.path;

            // Assert
            Assert.IsTrue(File.Exists(fileName));
        }

        [TestMethod]
        public void ReadTxtFile_LogInfoListNotNull()
        {
            // Arrange
            string fileName = Program.path;
            List<LogInfo> list = new();

            // Act
            list = FileReader.ReadTxtFile(fileName);

            // Assert
            Assert.IsNotNull(list);
        }
    }
}