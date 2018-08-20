using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Engine.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public class RelayCommand : ICommand
        {
            private BaseViewModel _viewModel;

            public RelayCommand(BaseViewModel action)
            {
                _viewModel = action;
            }

            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public virtual void Execute(object parameter)
            {

            }

            #endregion
        }
    }

}
