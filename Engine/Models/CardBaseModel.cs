using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;
using GameMechanicsLibrary;

namespace Engine.Models
{
    
    public class CardBaseModel : BaseModel
    {
        #region Constructor
        public CardBaseModel()
        {
            CardDetails = new Card();
        }
        #endregion

        #region Public Properties
        public string CardName { get; private set; }
        public string CardSpecs { get; private set; }
        public string Price { get; private set; }
        public string ImageLocation { get; private set; }
        public Card CardDetails { get; private set; }
        #endregion

        #region Public Methods
        public void GenerateCard(string cardName)
        {
            CardDetails.GenerateCardByName(cardName);
            ImageLocation = $"pack://application:,,,/Window;component/Images/{CardDetails.Name}.bmp";
            Price = $"${CardDetails.Cost}";
            CardSpecs = GenerateModuleSpecsText();

        }
        #endregion

        #region Private Methods
        private string GenerateModuleSpecsText()
        {
            string text = null;
            string samplingType = "Simultaneous";
            if (CardDetails.IsMultiplexed)
            {
                samplingType = "Multiplexed";
            }
            text = $"ADC Type:            {CardDetails.ADCType}\n" +
                   $"Signal Conditioning: {CardDetails.SignalConditioning}\n" +
                   $"Terminal Config.:    {CardDetails.TerminalConfig}\n" +
                   $"Measurement Range:   ±{CardDetails.MeasurementRange} V\n" +
                   $"Sample Rate:         {CardDetails.SampleRate} Hz\n" +
                   $"Sampling Mode:       {samplingType}\n";
            return text;

        }
        #endregion

    }
}
