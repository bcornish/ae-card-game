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
        private ButtonCommand Command;

        #region Constructor
        public LoginViewModel()
        {
            Model = new LoginModel();
            // Removed Command function to accommodate PasswordBox and the SecureString
            //Command = new ButtonCommand(this.LoginToAccount, Model.LoginCompleted);
        }

        #endregion

        #region Methods

        public void LoginToAccount(object parameter)
        {
            Model.Password = this.ConvertToUnsecureString(parameter as System.Security.SecureString);
            Model.ValidateAccountAndLogin();
        }

            /* Removed Command function to accommodate PasswordBox and the SecureString 
        public ICommand loginClick
        {
            get
            {
                return Command;
            }
        }*/

        public bool LoginValidated
        {
            get { return Model.LoginCompleted; }
        }
        public string Username
        {
            get { return Model.Username; }
        }
        public string Password
        {
            get { return Model.Password; }
        }
        #endregion

    }
}
