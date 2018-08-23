using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.SubSystems
{
    public class Sensor
    {
        public Signal Signal { get; private set; }
        public string Type { get; private set; }
        public bool IsGrounded { get; private set; }

        public void WriteDummySensorProperties()
        {
            Signal.WriteDummySignalProperties();
            Type = "Thermocouple"; // Could also be "Strain Gauge", "IEPE Sensor", and "Generic Voltage Sensor"
            IsGrounded = true; // Could be false
        }
    }
}
