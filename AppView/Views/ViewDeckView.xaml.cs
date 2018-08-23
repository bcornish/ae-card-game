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
using Engine.ViewModels.TabControlVM;

namespace MainWindow.Views
{
    /// <summary>
    /// Interaction logic for ViewDeckView.xaml
    /// </summary>
    public partial class ViewDeckView : UserControl
    {
        private readonly TabControlViewModel viewModel = new TabControlViewModel();
        public ViewDeckView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
