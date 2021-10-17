using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltedSecuredHashAlgorithm
{
    public class LogInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LogInfo(string name, string pass)
        {
            this.UserName = name;
            this.Password = pass;
        }

        public override string ToString()
        {
            return UserName.PadRight(20) + Password;
        }
    }
}
