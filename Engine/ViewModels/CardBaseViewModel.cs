using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    public class CardBaseViewModel
    {

        public CardBaseModel Model { get; set; }

        #region Constructor
        public CardBaseViewModel()
        {
            Model = new CardBaseModel();
            Model.ImageSourceLookup("NI 9237"); // this should be removed, it's just for my testing
        }

        #endregion

        #region Methods

        public void ImageSource()
        {

        }
        #endregion

    }
}
