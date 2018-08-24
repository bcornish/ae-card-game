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

        #region Constructor
        public SystemBaseModel()
        {
            SystemCardDetails = new SystemCard();
        }
        #endregion

        #region Public Properties
        public string SystemPayout { get; private set; }
        public string SystemRequirements { get; private set; }
        public SystemCard SystemCardDetails { get; private set; }
        public string ImageLocation { get; private set; }
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
