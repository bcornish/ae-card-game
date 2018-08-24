using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using System.Windows.Input;

namespace Engine.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {

        public LoginModel Model { get; set; }

        #region Constructor
        public LoginViewModel()
        {
            Model = new LoginModel();
        }

        #endregion

        #region Methods

        public void LoginToAccount(object parameter)
        {
            Model.Password = this.ConvertToUnsecureString(parameter as System.Security.SecureString);
            Model.ValidateAccountAndLogin();
        }
        #endregion

    }
}
