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
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        //private readonly MainWindowViewModel viewModel = new MainWindowViewModel();

        private readonly NavigationViewModel viewModel = new NavigationViewModel();

        public MainWindowView()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        //private void Button_Click_Create_Account(object sender, RoutedEventArgs e)
        //{
        //    Main.Content = new AccountCreationView();
        //}

        //private void Button_Click_Login(object sender, RoutedEventArgs e)
        //{
        //    Main.Content = new LoginView();
        //}
    }
}
