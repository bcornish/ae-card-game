using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.ViewModels;

namespace MainWindow.Views
{
    /// <summary>
    /// Interaction logic for AccountCreationView.xaml
    /// </summary>
    public partial class AccountCreationView : Page
    {
        private readonly AccountCreationViewModel viewModel = new AccountCreationViewModel();

        public AccountCreationView()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void OnClick_ValidateAccount(object sender, RoutedEventArgs e)
        {
            viewModel.ValidateAccount();
        }

        private void OnClick_CreateAccount(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
