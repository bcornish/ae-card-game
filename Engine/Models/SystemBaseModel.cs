using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class SystemBaseModel: BaseModel
    {
        private string name;
        private string payout;
        private string systemBaseImage;
        private string reqs;

        public SystemBaseModel()
        {
            name = null;
            reqs = null;
            systemBaseImage = null;
            payout = null;
        }

        public string SystemName
        {
            get { return name; }
            set
            {
                name = value;

                OnPropertyChanged(nameof(SystemName));
            }
        }
        public string SystemPayout
        {
            get { return payout; }
            set
            {
                payout = value;

                OnPropertyChanged(nameof(SystemPayout));
            }
        }

        public string SystemBaseImage
        {
            get { return systemBaseImage; }
            set
            {
                systemBaseImage = value;

                OnPropertyChanged(nameof(SystemBaseImage));
            }
        }
        public string SystemRequirements
        {
            get { return reqs; }
            set
            {
                reqs = value;

                OnPropertyChanged(nameof(SystemRequirements));
            }
        }
        public void ImageSourceLookup()
        {
            //TODO: implement logic to look up cards

            SystemBaseImage = "pack://application:,,,/Window;component/Blank Fake Card.bmp";
            SystemName = "NI 9215";
            SystemPayout = "$900";
            SystemRequirements = "Testing";

=======
=======
>>>>>>> 59d8ea72502cb6bca713449a8ceb76bf49426dd8
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
<<<<<<< HEAD
>>>>>>> 59d8ea72502cb6bca713449a8ceb76bf49426dd8
=======
>>>>>>> 59d8ea72502cb6bca713449a8ceb76bf49426dd8
        }
    }
}
