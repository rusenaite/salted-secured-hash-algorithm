using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SaltedSecuredHashAlgorithm
{
    public class Program
    {
        public const string path = "C:/Users/raust/source/repos/SaltedSecuredHashAlgorithm/log_info.txt";

        public static void Main()
        {
            // store given log-in information in .TXT file
            List<LogInfo> logInData = FileReader.ReadTxtFile(path);

            // secure log-in data
            List<LogInfo> hashedData = Hash.HashData(logInData);

            // store secured log-in information in another .TXT file
            FileWriter.WriteToTxt(hashedData);

        }
    }
}
