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
        #region Private Properties
        private string cardName;
        private string cardSpecs;
        private string price;
        private string imageLocation;
        private Card cardDetails;
        #endregion

        #region Constructor
        public CardBaseModel()
        {
            CardDetails = new Card();
        }
        #endregion

        #region Public Properties
        public string CardName
        {
            get { return cardName; }
            set
            {
                cardName = value;

                OnPropertyChanged(nameof(CardName));
            }
        }
        public string CardSpecs
        {
            get { return cardSpecs; }
            set
            {
                cardSpecs = value;

                OnPropertyChanged(nameof(CardSpecs));
            }
        }
        public string Price
        {
            get { return price; }
            set
            {
                price = value;

                OnPropertyChanged(nameof(Price));
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
        public Card CardDetails
        {
            get { return cardDetails; }
            set
            {
                cardDetails = value;

                OnPropertyChanged(nameof(CardDetails));
            }
        }
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
