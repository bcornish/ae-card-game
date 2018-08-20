using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class AccountCreationViewModel
    {
        
        public AccountCreationModel NewAccount { get; set;}
        
        #region Constructor
        public AccountCreationViewModel()
        {
            NewAccount = new AccountCreationModel();
        }

        #endregion

        #region Methods
        public void ValidatePassword()
        {
            NewAccount.ValidatePassword();
        }
        public void ValidateUsername()
        {
            NewAccount.ValidateUsername();
        }

        public void ValidateAccount()
        {
            NewAccount.ValidateFinalAccountMessage();
        }

        public string UsernameMessage()
        {
            return NewAccount.UsernameValidationMessage;
        }
        #endregion
    }
}
