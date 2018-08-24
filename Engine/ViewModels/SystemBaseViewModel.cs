using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    public class SystemBaseViewModel: BaseViewModel
    {
        public SystemBaseModel Model { get; set; }

        #region Constructor
        public SystemBaseViewModel()
        {
            Model = new SystemBaseModel();
            Model.ImageSourceLookup("Heartbeat"); // this should be removed, it's just for my testing
        }

        #endregion

        #region Methods

        public void ImageSource()
        {
        }
        #endregion

    }
}

