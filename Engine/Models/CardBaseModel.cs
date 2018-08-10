using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    
    public class CardBaseModel : INotifyPropertyChanged
    {
        private string modelNumber;
        private string specifications;
        
        private struct cardSize
        {
            private double width;
            private double height;
        }
        private enum size
        {
            Small = 1, Medium = 2, Large = 3
        }
        public string ModelNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;

                OnPropertyChanged(nameof(ModelNumber));
            }
        }
        public string Specs
        {
            get { return specifications; }
            set
            {
                specifications = value;

                OnPropertyChanged(nameof(Specs));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
