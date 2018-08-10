using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine.Models
{
    public class LoginModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private string usernameValidationMessage;
        private string passwordValidationMessage;
        private string accountValidationMessage;

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

        public void ValidateAccountAndLogin()
        {
            if (Username == "bcornish" && Password == "PurpleTomatoes9!")
                AccountValidationMessage = "Successful login";
            else
                AccountValidationMessage = "Failed login. Check username and password and try again.";

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
