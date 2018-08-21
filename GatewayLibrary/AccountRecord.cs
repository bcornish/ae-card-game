using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayLibrary
{
    public class AccountRecord
    {
        public string userName { get; set; }
        public string salt { get; set; }
        public string saltedHash { get; set; }

    }
}
