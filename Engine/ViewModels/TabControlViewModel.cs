using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Engine.ViewModels.TabControlVM
{
    public class TabControlViewModel : BaseViewModel
    {


        public TabControlViewModel()
        {

        }
    }
    public class ViewDeckViewModel : TabControlViewModel
    {

        public static string Name
        {
            get { return "View Deck"; }
        }

        public string Content
        {
            get { return "View Deck"; }
        }
    }

    public class PlayViewModel : TabControlViewModel
    {
        public static string Name
        {
            get { return "Play a Game"; }
        }

        public string Content
        {
            get { return "Phone Numbers Content"; }
        }
    }

    public class AddressesViewModel
    {
        public static string Name
        {
            get { return "Addresses"; }
        }

        public string Content
        {
            get { return "Addresses Content"; }
        }

    }

    public class ViewModel
    {
        public ViewModel()
        {
            Items.Add(new ViewDeckViewModel());
            Items.Add(new PlayViewModel());
        }
        public ObservableCollection<TabControlViewModel> Items { get; private set; }
        = new ObservableCollection<TabControlViewModel>();
    }

    public class ViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ViewDeckTemplate { get; set; }
        public DataTemplate ViewPlayTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ViewDeckViewModel)
            {
                return ViewDeckTemplate;
            }
                
            return ViewPlayTemplate;
        }
    }


}