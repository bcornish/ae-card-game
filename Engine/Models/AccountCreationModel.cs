using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GatewayLibrary;

namespace Engine.Models
{
    public class AccountCreationModel: BaseModel
    {
        private string username;
        private string password;
        private string usernameValidationMessage;
        private string passwordValidationMessage;
        private string accountValidationMessage;
        private bool passAccountCheck;
        private bool accountCreated;

        public AccountCreationModel()
        {
            username = null;
            password = null;
            accountValidationMessage = null;
            passAccountCheck = false;
            accountCreated = false;
        }

        public string Username
        {
            get { return username; }
            set { username = value;

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

        public string UsernameValidationMessage
        {
            get { return usernameValidationMessage; }
            set
            {
                usernameValidationMessage = value;

                OnPropertyChanged(nameof(UsernameValidationMessage));
            }
        }

        public string PasswordValidationMessage
        {
            get { return passwordValidationMessage; }
            set{
                passwordValidationMessage = value;

                OnPropertyChanged(nameof(PasswordValidationMessage));
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

        public bool AccountCheck
        {
            get { return passAccountCheck; }
            set
            {
                passAccountCheck = value;

                OnPropertyChanged(nameof(AccountCheck));
            }
        }

        public bool AccountCreated
        {
            get { return accountCreated; }
            set
            {
               accountCreated = value;

                OnPropertyChanged(nameof(AccountCreated));
            }
        }

        public bool ValidatePassword()
        {

            if (Password == null || Password.Trim().Length == 0)
            {
                PasswordValidationMessage = "\u2022 Password cannot be empty. \n";
            }
            else
            {
                PasswordValidationMessage = null;
                if (Password.Trim().Length < 8)
                {
                    PasswordValidationMessage += "\u2022 Password must be at least 8 characters long. \n";
                }
                if (Password.Trim().Length > 20)
                {
                    PasswordValidationMessage += "\u2022 Password cannot be more than 20 characters long. \n";
                }
                if (!(Password.Any(char.IsUpper)))
                {
                    PasswordValidationMessage += "\u2022 Password must contain at least one uppercase letter. \n";
                }
                if (!(Password.Any(char.IsLower)))
                {
                    PasswordValidationMessage += "\u2022 Password must contain at least one lowercase letter. \n";
                }
                if (!(Password.Any(char.IsNumber)))
                {
                    PasswordValidationMessage += "\u2022 Password must contain at least one number. \n";
                }
                if (!(Password.Any(char.IsSymbol) || Password.Any(char.IsPunctuation)))
                {
                    PasswordValidationMessage += "\u2022 Password must contain at least one symbol. \n";
                }
                if ((Password.Any(char.IsWhiteSpace)))
                {
                    PasswordValidationMessage += "\u2022 Password cannot contain spaces. \n";
                }
            }
            if (PasswordValidationMessage == null)
            {
                PasswordValidationMessage = "\u2022 Password is acceptable. \n";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUsername()
        {
            //check account database for existing username
            AccountDatabase database = new AccountDatabase();
            database.OpenConnection();
            //if there is an existing account, update the validation message
            if(database.LookUpAccountRecord(Username, Password).ErrorString != "no record found")
            {
                usernameValidationMessage = "\u2022 Username already exists. \n";
            }
            else if (Username == null || Username.Trim().Length == 0)
            {
                UsernameValidationMessage = "\u2022 Username cannot be empty. \n";
            }
            else
            {
                UsernameValidationMessage = null;
                if (Username.Trim().Length < 7)
                {
                    UsernameValidationMessage += "\u2022 Username must be at least 7 characters long. \n";
                }
                if (Username.Trim().Length > 20)
                {
                    UsernameValidationMessage += "\u2022 Username cannot be more than 20 characters long. \n";
                }
                if ((Username.Any(char.IsWhiteSpace)))
                {
                    UsernameValidationMessage += "\u2022 Username cannot contain spaces. \n";
                }
            }
            //close connection to account database
            database.CloseConnection();
            //if username has not been disqualified send an acceptable message
            if (UsernameValidationMessage == null)
            {
                UsernameValidationMessage = "\u2022 Username is acceptable. \n";
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ValidateAccount()
        {
            bool usernameCheck = this.ValidateUsername();
            bool passwordCheck = this.ValidatePassword();
            AccountValidationMessage = UsernameValidationMessage + PasswordValidationMessage;
            AccountCheck = usernameCheck && passwordCheck;
        }

        public void CreateAccount()
        {
            //open a connection to the account database
            AccountDatabase database = new AccountDatabase();
            database.OpenConnection();
            //send the request to generate a new account and store result in accountCreated property
            AccountRecord newlyCreatedAccount = new AccountRecord();
            newlyCreatedAccount.Username = Username;
            AccountCreated = database.AddAccountRecord(newlyCreatedAccount, Password);
            //close connection to the account database
            database.CloseConnection();
            AccountCreated = true;
            if (AccountCheck && AccountCreated)
            {
                AccountValidationMessage = "\u2022 Account created.  Log in to play!";
            }
        }
    }

    
}
