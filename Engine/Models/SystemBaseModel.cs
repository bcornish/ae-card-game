using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;
using GameMechanicsLibrary;

namespace Engine.Models
{

    public class SystemBaseModel: BaseModel
    {
        #region Private Properties
        private string systemPayout;
        private string systemRequirements;
        private SystemCard systemCardDetails;
        private string imageLocation;
        #endregion
        #region Constructor
        public SystemBaseModel()
        {
            SystemCardDetails = new SystemCard();
        }
        #endregion

        #region Public Properties
        public string SystemPayout
        {
            get { return systemPayout; }
            set
            {
                systemPayout = value;

                OnPropertyChanged(nameof(SystemPayout));
            }
        }
        public string SystemRequirements
        {
            get { return systemRequirements; }
            set
            {
                systemRequirements = value;

                OnPropertyChanged(nameof(SystemRequirements));
            }
        }
        public SystemCard SystemCardDetails
        {
            get { return systemCardDetails; }
            set
            {
                systemCardDetails = value;

                OnPropertyChanged(nameof(SystemCardDetails));
            }
        }
        public string ImageLocation
        {
            get { return imageLocation; }
            set
            {
                imageLocation = value;

                OnPropertyChanged(nameof(ImageLocation));
            }
        }
        #endregion

        #region Public Methods
        public void GenerateSystem(string systemName)
        {
            SystemCardDetails.GenerateSystemByName(systemName);
            ImageLocation = $"pack://application:,,,/Window;component/Images/{SystemCardDetails.SensorType}.bmp";
            SystemRequirements = GenerateSensorReqsText();
        }
        #endregion

        #region Private Methods
        private string GenerateSensorReqsText()
        {
            string text = null;
            string grounding = "Floating";
            if (SystemCardDetails.IsGrounded)
            {
                grounding = "Grounded";
            }
            string freqText = "DC";
            if (SystemCardDetails.SignalFrequency != 0)
            {
                freqText = $"{SystemCardDetails.SignalFrequency} Hz";
            }
            text = $"Type of Sensor:   {SystemCardDetails.SensorType}\n" +
                   $"Desired Content:  {SystemCardDetails.DesiredContent}\n" +
                   $"Signal Amplitude: ±{SystemCardDetails.SignalAmplitude} V\n" +
                   $"Signal Frequency: {freqText}\n" +
                   $"Grounding:        {grounding}\n";
            return text;

        }
        #endregion
    }
}
