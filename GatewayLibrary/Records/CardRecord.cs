using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayLibrary.Records
{
    public class CardRecord : GameElementRecord
    {

        public string ADCType { get; set; }
        public string SignalConditioning { get; set; }
        public string TerminalConfig { get; set; }
        public string MeasurementRange { get; set; }
        public string SampleRate { get; set; }
        public string IsMultiplexed { get; set; }
    }
}
