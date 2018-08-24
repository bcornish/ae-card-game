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
