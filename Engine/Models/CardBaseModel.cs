using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    
    public class CardBaseModel : BaseModel
    {
        #region Original Properties
        private string modelNumber;
        private string specifications;
        private string cardBaseImage;
        private string price;

        public CardBaseModel()
        {
            modelNumber = null;
            specifications = null;
            cardBaseImage = null;
            price = null;
        }
        public string ModuleNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;

                OnPropertyChanged(nameof(ModuleNumber));
            }
        }
        public string ModuleSpecs
        {
            get { return specifications; }
            set
            {
                specifications = value;

                OnPropertyChanged(nameof(ModuleSpecs));
            }
        }
        public string ModulePrice
        {
            get { return price; }
            set
            {
                price = value;

                OnPropertyChanged(nameof(ModulePrice));
            }
        }
        public string CardBaseImage
        {
            get { return cardBaseImage; }
            set
            {
                cardBaseImage = value;

                OnPropertyChanged(nameof(CardBaseImage));
            }
        }
        #endregion

        public string Name { get; private set; }
        public string ImageLocation { get; private set; }
        public string Description { get; private set; }
        public bool IsDSA { get; private set; }
        public string SignalConditioning { get; private set; }
        public string TerminalConfig { get; private set; }
        public int MeasurementRange { get; private set; }
        public int SampleRate { get; private set; }
        public bool IsMultiplexed { get; private set; }

        public void WriteDummyCardData()
        {
            Name = "NI 9215";
            ImageLocation = "pack://application:,,,/Window;component/Blank Fake Card.bmp";
            Description = "This is a C Series Module.  It reads signals";
            IsDSA = false;
            SignalConditioning = "None"; // Could also be "Bridge Completion", "CJC", "IEPE"
            TerminalConfig = "Differential"; // Could also be "Single-Ended"
            MeasurementRange = 10;
            SampleRate = 100000;
            IsMultiplexed = false;
        }
        public void ImageSourceLookup()
        {
            //TODO: implement logic to look up cards
 
            CardBaseImage = "pack://application:,,,/Window;component/Blank Fake Card.bmp";
            ModuleNumber = "NI 9215";
            ModulePrice = "$900";
            ModuleSpecs = "Testing";
                       
    }
    }
}
