using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class TabModel : BaseModel
    {
        private string passFailImage;

        public string PassFailImage
        {
            get { return passFailImage; }
            set
            {
                passFailImage = value;

                OnPropertyChanged(nameof(PassFailImage));
            }
        }
    }
}
