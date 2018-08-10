using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine.ViewModels;

namespace TestEngine
{
    [TestClass]
    public class TestAccountCreation
    {
        [TestMethod]
        public void Test_PasswordIsEmpty()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password cannot be empty. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordIsTooShort()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "1!aA";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password must be at least 8 characters long. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordIsTooLong()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "1!aA?0123456789ABCDEF";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password cannot be more than 20 characters long. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordNoUpper()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "testing8!";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password must contain at least one uppercase letter. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }
        [TestMethod]
        public void Test_PasswordNoLower()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "TESTING8!";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password must contain at least one lowercase letter. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordNoNumber()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "Testing!";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password must contain at least one number. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordNoSymbol()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "Testing8";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password must contain at least one symbol. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordHasSpaces()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "Testing8 !";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password cannot contain spaces. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_PasswordValid()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Password = "TestinG8!";
            viewModel.ValidatePassword();

            Assert.AreEqual("\u2022 Password is acceptable. \n",
                viewModel.NewAccount.PasswordValidationMessage);
        }

        [TestMethod]
        public void Test_UsernameIsEmpty()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Username = "";
            viewModel.ValidateUsername();

            Assert.AreEqual("\u2022 Username cannot be empty. \n",
                viewModel.NewAccount.UsernameValidationMessage);
        }

        [TestMethod]
        public void Test_UsernameIsTooShort()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Username = "1!aA";
            viewModel.ValidateUsername();

            Assert.AreEqual("\u2022 Username must be at least 7 characters long. \n",
                viewModel.NewAccount.UsernameValidationMessage);
        }

        [TestMethod]
        public void Test_UsernameIsTooLong()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Username = "1!aA?0123456789ABCDEF";
            viewModel.ValidateUsername();

            Assert.AreEqual("\u2022 Username cannot be more than 20 characters long. \n",
                viewModel.NewAccount.UsernameValidationMessage);
        }

        [TestMethod]
        public void Test_UsernameHasSpaces()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Username = "Testing8 !";
            viewModel.ValidateUsername();

            Assert.AreEqual("\u2022 Username cannot contain spaces. \n",
                viewModel.NewAccount.UsernameValidationMessage);
        }

        [TestMethod]
        public void Test_UsernameValid()
        {
            AccountCreationViewModel viewModel = new AccountCreationViewModel();
            viewModel.NewAccount.Username = "TestinG8!";
            viewModel.ValidateUsername();

            Assert.AreEqual("\u2022 Username is acceptable. \n",
                viewModel.NewAccount.UsernameValidationMessage);
        }
    }
}
