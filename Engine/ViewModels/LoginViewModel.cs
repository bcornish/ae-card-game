using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.ViewModels
{
    public class LoginViewModel
    {

        public LoginModel Model { get; set; }

        #region Constructor
        public LoginViewModel()
        {
            Model = new LoginModel();
        }

        #endregion

        #region Methods

        public void LoginToAccount()
        {
            Model.ValidateAccountAndLogin();
        }

        public bool LoginValidated()
        {
            return Model.LoginCompleted;
        }
        #endregion


    }
}
