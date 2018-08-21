using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayLibrary
{
    //class containing account record information
    public class AccountRecord
    {
        public string Username { get; set; }
        public string Salt { get; set; }
        public string SaltedHash { get; set; }
        public string ErrorString { get; set; }
    }
}
