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
using Engine.ViewModels.TabControlVM;

namespace MainWindow.Views
{
    /// <summary>
    /// Interaction logic for StartPlayview.xaml
    /// </summary>
    public partial class StartPlayView : Page
    {
        private readonly StartPlayViewModel viewModel = new StartPlayViewModel();
        public StartPlayView()
        {
            InitializeComponent();

            DataContext = viewModel;
        }
       
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataTemplate template = new DataTemplate();
            //DataTemplateKey playKey = new DataTemplateKey(typeof(ViewDeckViewModel));
            //DataTemplateKey deckKey = new DataTemplateKey(typeof(PlayViewModel));
            //if (e.Source is TabControl)
            //{
            //    if (((TabControl)sender).SelectedItem is ViewDeckViewModel)
            //    {
            //        template = (DataTemplate)this.FindResource(deckKey);
            //    }

            //    if (((TabControl)sender).SelectedItem is PlayViewModel)
            //    {
            //        template = (DataTemplate)this.FindResource(playKey);
            //    }
            //}
            
            //((TabControl)sender).ContentTemplate = template;
      
        }
    }
}
