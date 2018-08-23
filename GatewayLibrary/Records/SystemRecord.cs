using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayLibrary.Records
{
    public class SystemRecord
    {
        // TODO: Try to replace this with something more dynamic that can pull a dynamic number of sensors and other objects into it
        public string SystemName { get; set; }
        public string ImageLocation { get; set; }
        public string Sensor1 { get; set; }
        public string Sensor2 { get; set; }
        public string Sensor3 { get; set; }
       
    }
}
