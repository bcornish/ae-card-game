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
        public LoginModel()
        {
            AccountValidationMessage = "";
            Password = "password";
            Username = "username";
            LoginCompleted = true;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountValidationMessage { get; set; }
        public bool LoginCompleted { get; set; }

        public void ValidateAccountAndLogin()
        {
            // Open connection to the Account Database
            AccountDatabase database = new AccountDatabase();
            database.OpenConnection();
            // Check whether the username/password combination is valid or not
            AccountRecord loginAccount = database.LookUpAccountRecord(Username, Password);
            
            if (loginAccount.ErrorString == "valid record")
            {
                AccountValidationMessage = "Successful login.  You may now begin playing.";
                LoginCompleted = true;
            }
            else
            {
                AccountValidationMessage = "Failed login. Check username and password and try again.";
                LoginCompleted = false;
            }
            database.CloseConnection();
        }
    }
}
