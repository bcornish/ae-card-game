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
        }

        #endregion

        #region Methods

        #endregion

    }
}
