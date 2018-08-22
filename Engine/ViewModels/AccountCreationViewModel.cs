using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Engine.ViewModels
{
    public class AccountCreationViewModel: BaseViewModel
    {
        
        public AccountCreationModel NewAccount { get; set;}
        private ButtonCommand ValidateCommand;
        private ButtonCommand CreateCommand;

        #region Constructor
        public AccountCreationViewModel()
        {
            NewAccount = new AccountCreationModel();
            ValidateCommand = new ButtonCommand(this.ValidateAccount, true);
            CreateCommand = new ButtonCommand(this.CreateAccount, true);
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
            //NewAccount.Password = ConvertToUnsecureString(parameter as System.Security.SecureString);
            NewAccount.ValidateAccount();
        }

        public void CreateAccount()
        {
            //NewAccount.Password = ConvertToUnsecureString(parameter as System.Security.SecureString);
            NewAccount.ValidateAccount();
            if (NewAccount.AccountCheck)
            {
                NewAccount.CreateAccount();
            }
        }
        public string UsernameMessage()
        {
            return NewAccount.UsernameValidationMessage;
        }
        #endregion
        public ICommand validateClick
        {
            get
            {
                return ValidateCommand;
            }
        }

        public ICommand createClick
        {
            get
            {
                return CreateCommand;
            }
        }
    }
}
