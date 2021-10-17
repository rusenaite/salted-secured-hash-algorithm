using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SaltedSecuredHashAlgorithm
{
    public class FileReader
    {
        public static List<LogInfo> ReadTxtFile(string fileName)
        {
            List<LogInfo> logInInfoList = new();

            using (FileStream fs = File.Open(fileName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.ASCII))
                {
                    logInInfoList = ParseTxtFile(sr);
                }
            }

            return logInInfoList;
        }

        public static List<LogInfo> ParseTxtFile(StreamReader stream)
        {
            List<LogInfo> list = new();

            string fileText = stream.ReadToEnd();
            string[] lines = fileText.Split('\n');

            foreach (string line in lines)
            {
                int lineSplit = line.IndexOf(" ");

                if (lineSplit >= 0)
                {
                    string userName = line.Substring(0, lineSplit);
                    string password = line.Substring(lineSplit + 1);

                    LogInfo logInfo = new(userName, password);

                    list.Add(logInfo);
                }
            }

            return list;
        }
    }
}
