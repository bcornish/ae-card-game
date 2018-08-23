using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayLibrary.Records
{
    public class SensorRecord : GameElementRecord
    {

        public string DesiredContent { get; set; }
        public string SignalAmplitude { get; set; }
        public string SignalFrequency { get; set; }
        public string Type { get; set; }
        public string IsGrounded { get; set; }
    }
}
