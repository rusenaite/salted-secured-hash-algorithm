using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltedSecuredHashAlgorithm
{
    public class FileWriter
    {
        public static void WriteToTxt(List<LogInfo> list)
        {
            string path = "C:/Users/raust/source/repos/SaltedSecuredHashAlgorithm/";
            
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "hashed_log_info.txt"), true))
            {
                foreach (var logIn in list)
                {
                    outputFile.WriteLine(logIn);
                }
            }
        }

    }
}
