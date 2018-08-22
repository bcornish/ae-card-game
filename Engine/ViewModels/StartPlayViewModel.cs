using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Engine.ViewModels
{
   public class StartPlayViewModel: BaseViewModel
    {
        private ButtonCommand ViewDeckCommand;
        private ButtonCommand PlayCommand;

        #region Constructor
        public StartPlayViewModel()
        {
         //   Model = new LoginModel();
            ViewDeckCommand = new ButtonCommand(OpenAny<LoginViewModel>, true);
            PlayCommand = new ButtonCommand(OpenAny<LoginViewModel>, true);
        }
        #endregion

        public ICommand PlayClick
        {
            get { return PlayCommand; }
        }
        public ICommand ViewDeckClick
        {
            get { return ViewDeckCommand; }
        }
    }
}
