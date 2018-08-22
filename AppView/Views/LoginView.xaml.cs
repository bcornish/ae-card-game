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
using System.Windows.Shapes;
using Engine.ViewModels;

namespace MainWindow.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        private readonly LoginViewModel viewModel = new LoginViewModel();

        public LoginView()
        {
            InitializeComponent();

            DataContext = viewModel;
        }
        
        private void OnClick_Login(object sender, RoutedEventArgs e)
        {
            viewModel.LoginToAccount(userPassword.SecurePassword);
        }
    }
}
