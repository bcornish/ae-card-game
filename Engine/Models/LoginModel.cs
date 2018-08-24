using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GatewayLibrary;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;

namespace Engine.Models
{
    public class LoginModel : BaseModel
    {
        private string username;
        private string password;
        private string usernameValidationMessage;
        private string passwordValidationMessage;
        private string accountValidationMessage;
        private bool loginSuccess;

        public LoginModel()
        {
            username = "username";
            password = "password";
            accountValidationMessage = null;
            loginSuccess = true;
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;

                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;

                OnPropertyChanged(nameof(Password));
            }
        }

        public string AccountValidationMessage
        {
            get { return accountValidationMessage; }
            set
            {
                accountValidationMessage = value;

                OnPropertyChanged(nameof(AccountValidationMessage));
            }
        }

        public bool LoginCompleted
        {
            get { return loginSuccess; }
            set
            {
                loginSuccess = value;

                OnPropertyChanged(nameof(LoginCompleted));
            }
        }

        public void ValidateAccountAndLogin()
        {
            // Open connection to the Account Database
            AccountDatabase database = new AccountDatabase();
            database.OpenConnection();
            // Check whether the username/password combination is valid or not
            AccountRecord loginAccount = database.LookUpAccountRecord(Username, Password);
            if (loginAccount.ErrorString == "valid record")
            {
                AccountValidationMessage = "Successful login";
                LoginCompleted = true;
            }
            else
            {
                AccountValidationMessage = "Failed login. Check username and password and try again.";
                LoginCompleted = false;
            }           
        }
    }
}
