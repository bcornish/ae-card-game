using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Engine.ViewModels
{
    public class NavigationViewModel: BaseViewModel
    {
        private ButtonCommand LoginCommand;
        private ButtonCommand AccountCommand;
        private ButtonCommand HomeCommand;

        public bool selected = true;

        #region Constructor
        public NavigationViewModel()
        {
            LoginCommand = new ButtonCommand(OpenAny<LoginViewModel>, this.selected);
            AccountCommand = new ButtonCommand(OpenAny<AccountCreationViewModel>, this.selected);
            HomeCommand = new ButtonCommand(OpenAny<StartPlayViewModel>, this.selected);
        }

        #endregion

        public ICommand LoginClick
        {
            get { return LoginCommand; }
            
        }
        public ICommand AccountClick
        {
            get { return AccountCommand; }
    
        }
        public ICommand HomeClick
        {
            get { return HomeCommand; }
        }
    }
}
