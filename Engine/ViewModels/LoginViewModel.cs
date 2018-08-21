﻿using System;
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
            Command = new ButtonCommand(this.LoginToAccount, Model.LoginCompleted);
        }

        #endregion

        #region Methods

        public void LoginToAccount()
        {
            Model.ValidateAccountAndLogin();
        }
        //public class LoginToAccountCommand : RelayCommand
        //{
        //    private LoginViewModel viewModel;
        //    public LoginToAccountCommand(LoginViewModel VM): base(VM)
        //    {
        //        viewModel = VM;
        //    }
        //    public new bool CanExecute(object parameter)
        //    {
        //        return true;
        //    }
        //    public override void Execute(object parameter)
        //    {
        //        viewModel.LoginToAccount();
        //    }
        //}

        public ICommand loginClick
        {
            get
            {
                return Command;
            }
        }

        public bool LoginValidated()
        {
            return Model.LoginCompleted;
        }
        #endregion

    }
}
