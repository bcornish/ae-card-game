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
            //using an onclick method to address passwordbox limitations
            viewModel.LoginToAccount(userPassword.SecurePassword);
        }
        private void Username_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "username")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }
        private void Username_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "username";
                tb.Foreground = Brushes.LightGray;
            }
        }
        private void Password_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "password")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }
        private void Password_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "password";
                tb.Foreground = Brushes.LightGray;
            }
        }
    }
}
