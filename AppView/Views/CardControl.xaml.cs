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
using GameMechanicsLibrary;

namespace MainWindow.Views
{
    /// <summary>
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        private readonly CardBaseViewModel viewModel;
        private string module;

        public CardControl()
        {
            module = "NI 9215";
            viewModel = new CardBaseViewModel(module);
            InitializeComponent();

            DataContext = viewModel;
        }

        private void ImageSourceQuery(object sender, RoutedEventArgs e)
        {
           // viewModel.ImageSource();
        }

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    viewModel.UpdateCard("NI 9215");
        //}
    }
}
