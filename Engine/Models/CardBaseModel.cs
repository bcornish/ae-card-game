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
        private string modelNumber;
        private string specifications;
        private string cardBaseImage;
        private string price;
        

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

        public void ImageSourceLookup()
        {
            //TODO: implement logic to look up cards
            CardBaseImage = "/AccountCreationView;component/Blank Fake Card.bmp";
            ModuleNumber = "NI 9215";
            ModulePrice = "$700";
            ModuleSpecs = "Testing";
        }
    }
}
