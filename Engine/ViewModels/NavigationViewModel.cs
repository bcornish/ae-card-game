using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Engine.Models;

namespace Engine.ViewModels
{
    public class NavigationViewModel: BaseViewModel
    {
        private ButtonCommand LoginCommand;
        private ButtonCommand AccountCommand;
        private ButtonCommand PlayCommand;
        private object selectedViewModel;
        public bool selected = true;

        #region Constructor
        public NavigationViewModel()
        {
            LoginCommand = new ButtonCommand(this.OpenLogin, this.selected);
            AccountCommand = new ButtonCommand(this.OpenAccount, this.selected);
            PlayCommand = new ButtonCommand(this.OpenPlay, this.selected);
        }

        #endregion



        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;

                NotifyPropertyChanged(nameof(SelectedViewModel));
            }
        }
        private void OpenLogin()
        {
            SelectedViewModel = new LoginViewModel();
        }
        private void OpenAccount()
        {
            SelectedViewModel = new AccountCreationViewModel();
        }
        private void OpenPlay()
        {
            SelectedViewModel = new AccountCreationViewModel();
        }
        public ICommand LoginClick
        {
            get
            {
                return LoginCommand;
            }
        }
        public ICommand AccountClick
        {
            get
            {
                return AccountCommand;
            }
        }
        public ICommand PlayClick
        {
            get
            {
                return PlayCommand;
            }
        }
    }
}
