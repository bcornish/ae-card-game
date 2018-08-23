using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;

namespace Engine.Models
{

    public class SystemBaseModel: BaseModel
    {
        #region Original Properties
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
        #endregion

        public string Name { get; private set; }
        public string ImageLocation { get; private set; }
        public string Description { get; private set; }
        public string DesiredContent { get; private set; }
        public decimal SignalAmplitude { get; private set; }
        public int SignalFrequency { get; private set; }
        public string SensorType { get; private set; }
        public bool IsGrounded { get; private set; }
        // Sensor class got deleted at some point, and I didn't feel like re-adding them yet
        // public List<SubSystems.Sensor> sensors { get; private set; } 

        public void MapSignalRecordToModel(string name)
        {
            // Open Card Database
            SensorDatabase database = new SensorDatabase();
            database.OpenConnection();
            // Request CardRecord from Database
            SensorRecord record = database.RequestSensorByName(name);
            database.CloseConnection();
            // Map CardRecord to CardBaseModel
            Name = record.Name;
            ImageLocation = $"pack://application:,,,/Window;component/Images/{record.Type}.bmp";
            Description = record.Description;
            DesiredContent = record.DesiredContent;
            SignalAmplitude = Convert.ToDecimal(record.SignalAmplitude);
            if (record.SignalFrequency != "DC")
            {
                SignalFrequency = Convert.ToInt32(record.SignalFrequency);
            }
            else
            {
                SignalFrequency = 0;
            }
            SensorType = record.Type;
            IsGrounded = (record.IsGrounded == "Yes");
        }

        private string GenerateSensorReqsText()
        {
            string text = null;
            string grounding = "Floating";
            if (IsGrounded)
            {
                grounding = "Grounded";
            }
            string freqText = "DC";
            if (SignalFrequency != 0)
            {
                freqText = $"{SignalFrequency}";
            }
            text = $"Desired Signal Content: {DesiredContent}\n" +
                   $"Signal Amplitude: ±{SignalAmplitude} V\n" +
                   $"Signal Frequency: {SignalFrequency} Hz\n" +
                   $"Type of Sensor: {SensorType}\n" +
                   $"Grounding: {grounding}\n\n" +
                   $"\"{Description}\"\n";
            return text;

        }
        public void ImageSourceLookup(string systemName)
        {
            //TODO: implement logic to look up cards
            MapSignalRecordToModel(systemName);
            SystemBaseImage = ImageLocation;
            SystemName = Name;
            SystemPayout = "Sensor";
            SystemRequirements = GenerateSensorReqsText();
        }
            
        }
}
