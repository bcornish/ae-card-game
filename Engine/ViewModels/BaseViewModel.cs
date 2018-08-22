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

        //public class RelayCommand : ICommand
        //{
        //    private BaseViewModel _viewModel;

        //    public RelayCommand(BaseViewModel action)
        //    {
        //        _viewModel = action;
        //    }

        //    #region ICommand Members

        //    public bool CanExecute(object parameter)
        //    {
        //        return true;
        //    }

        //    public event EventHandler CanExecuteChanged;

        //    public virtual void Execute(object parameter)
        //    {

        //    }
        //    #endregion
        //}
        //Generalized Command class for buttons for binding
        public class ButtonCommand : ICommand
        {
            private Action WhattoExecute;
            //private Func<bool> WhentoExecute;
            private bool WhentoExecute;

            public ButtonCommand(Action action, bool when)
            {
                WhattoExecute = action;
                WhentoExecute = when;
            }

            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return WhentoExecute;
            }

            public event EventHandler CanExecuteChanged;

            public virtual void Execute(object parameter)
            {
                WhattoExecute();
            }

            #endregion
            }
        //getting passwords out of passwordbox requires this.  I have no idea how it works
        protected string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;

                NotifyPropertyChanged(nameof(SelectedViewModel));
            }
        }
        protected void OpenAny<T>() where T : new()
        {
            SelectedViewModel = new T();
        }
    }

}