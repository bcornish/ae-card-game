using Engine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GameMechanicsLibrary;
using System.Windows.Input;

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

        public ViewDeckViewModel()
        {
            //**THIS CODE BELONGS HERE**//
            CardDealer dealer = new CardDealer();
            List<Card> cards = dealer.ListAllCards();

            ////**THIS CODE BELONGS IN THE PLAYDECK**//
            //CardDealer dealer = new CardDealer();
            //SystemCard sensor = dealer.ChooseRandomSensor();
            //List<Card> cards = dealer.DealCardsForSensor(sensor);
            // The text for the cards can be found in cards[n].Name
            // The text for the sensor can be found in sensor.Name


            this.Items = new ObservableCollection<CardBaseViewModel>();
            this.Items.Add(new CardBaseViewModel(cards[0].Name));
            this.Items.Add(new CardBaseViewModel(cards[1].Name));
            this.Items.Add(new CardBaseViewModel(cards[2].Name));
            this.Items.Add(new CardBaseViewModel(cards[3].Name));
            this.Items.Add(new CardBaseViewModel(cards[4].Name));
            this.Items.Add(new CardBaseViewModel(cards[5].Name));


        }
        public ObservableCollection<CardBaseViewModel> Items { get; private set; }
        

        //public CardBaseModel[] GetModules(string Module)
        //{
        //    return new CardBaseModel[]
        //    {
        //        new CardBaseModel(Module),
        //        new CardBaseModel("NI 9237"),
        //        new CardBaseModel("NI 9237"),
        //        new CardBaseModel("NI 9237")
        //    };
        //}
    }


    public class PlayViewModel : TabControlViewModel
    {
        public bool CorrectAnswer { get; set; }

        public TabModel Model { get; set; }

        public static string Name
        {
            get { return "Play a Game"; }
        }

        public string Content
        {
            get { return "Phone Numbers Content"; }
        }
        public PlayViewModel()
        {
            Model = new TabModel();
            CardDealer dealer = new CardDealer();
            SystemCard sensor = dealer.ChooseRandomSensor();
            List<Card> cards = dealer.DealCardsForSensor(sensor);
            this.Items = new ObservableCollection<CardBaseViewModel>();
            this.Items.Add(new CardBaseViewModel(cards[0].Name));
            this.Items.Add(new CardBaseViewModel(cards[1].Name));
            this.Items.Add(new CardBaseViewModel(cards[2].Name));
            this.OtherItems = new ObservableCollection<SystemBaseViewModel>();
            this.OtherItems.Add(new SystemBaseViewModel(sensor.Name));

            SelectLeftCommand = new ButtonCommand(this.CheckLeft,true);
            SelectMiddleCommand = new ButtonCommand(this.CheckMiddle, true);
            SelectRightCommand = new ButtonCommand(this.CheckRight, true);
        }
        public ObservableCollection<CardBaseViewModel> Items { get; private set; }
        public ObservableCollection<SystemBaseViewModel> OtherItems { get; private set; }

        public ButtonCommand SelectLeftCommand;
        public ButtonCommand SelectMiddleCommand;
        public ButtonCommand SelectRightCommand;

        public void CheckLeft()
        {
            CardMatcher matcher = new CardMatcher();
            Card card = Items[0].Model.CardDetails;
            SystemCard system = OtherItems[0].Model.SystemCardDetails;
            if(matcher.CheckForMatch(card, system))
            {
                CorrectAnswer = true;
                Model.PassFailImage = $"pack://application:,,,/Window;component/Images/Checkmark.png";
            }
            else
            {
                Model.PassFailImage = "pack://application:,,,/Window;component/Images/Red X.png";
            }
        }
        public void CheckMiddle()
        {
            CardMatcher matcher = new CardMatcher();
            Card card = Items[1].Model.CardDetails;
            SystemCard system = OtherItems[0].Model.SystemCardDetails;
            if (matcher.CheckForMatch(card, system))
            {
                CorrectAnswer = true;
                Model.PassFailImage = $"pack://application:,,,/Window;component/Images/Checkmark.png";
            }
            else
            {
                Model.PassFailImage = "pack://application:,,,/Window;component/Images/Red X.png";
            }
        }
        public void CheckRight()
        {
            CardMatcher matcher = new CardMatcher();
            Card card = Items[2].Model.CardDetails;
            SystemCard system = OtherItems[0].Model.SystemCardDetails;
            if (matcher.CheckForMatch(card, system))
            {
                CorrectAnswer = true;
                Model.PassFailImage = $"pack://application:,,,/Window;component/Images/Checkmark.png";
            }
            else
            {
                Model.PassFailImage = "pack://application:,,,/Window;component/Images/Red X.png";
            }
        }

        public ICommand selectLeftCard
        {
            get
            {
                return SelectLeftCommand;
            }
        }
        public ICommand selectMiddleCard
        {
            get
            {
                return SelectMiddleCommand;
            }
        }
        public ICommand selectRightCard
        {
            get
            {
                return SelectRightCommand;
            }
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