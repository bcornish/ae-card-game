using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class SystemBaseModel : BaseModel
    {
        public string Name { get; private set; }
        public string ImageLocation { get; private set; }
        public string Description { get; private set; }
        public string DesiredContent { get; private set; }
        public List<SubSystems.Sensor> sensors { get; private set; }

        public void CreateDummyRequirements()
        {
            Name = "Dummy System";
            ImageLocation = "C:/fake/location";
            Description = "This system is super easy!";
            DesiredContent = "FFT (Frequency Data)"; // Could also be "Signal Waveform (Time Domain)"

            SubSystems.Sensor dummySensor = new SubSystems.Sensor();
            dummySensor.WriteDummySensorProperties();
            sensors.Add(dummySensor);
            sensors.Add(dummySensor);
            sensors.Add(dummySensor);
        }
    }
}
