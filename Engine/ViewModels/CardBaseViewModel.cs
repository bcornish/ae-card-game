using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
    public class CardBaseViewModel
    {

        public CardBaseModel Model { get; set; }

        #region Constructor
        public CardBaseViewModel(string Module)
        {
            Model = new CardBaseModel();

            Model.GenerateCard(Module); // this should be removed, it's just for my testing
        }

        //public CardBaseViewModel()
        //{
        //    Model = new CardBaseModel();
        //    //Model.ImageSourceLookup("NI 9237"); // this should be removed, it's just for my testing
        //}

        #endregion

        #region Methods

        public void ImageSource()
        {

        }

        public void UpdateCard(string moduleName)
        {
            Model.GenerateCard(moduleName);
        }
        #endregion


    }

    public class ViewModel: BaseViewModel
    {
        public ViewModel()
        {
            Items.Add(new CardBaseViewModel("NI 9237"));
            Items.Add(new CardBaseViewModel("NI 9215"));
            Items.Add(new CardBaseViewModel("NI 9215"));
        }
        public ObservableCollection<CardBaseViewModel> Items { get; private set; }
        = new ObservableCollection<CardBaseViewModel>();
    }
}
