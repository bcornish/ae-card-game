using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Engine.ViewModels.TabControlVM.TabControlViewModel;

namespace Engine.ViewModels
{
   public class StartPlayViewModel: BaseViewModel
    {
        private ButtonCommand ViewDeckCommand;
        private ButtonCommand PlayCommand;
        ObservableCollection<object> _children;
        #region Constructor
        public StartPlayViewModel()
        {
         //   Model = new LoginModel();
            ViewDeckCommand = new ButtonCommand(OpenAny<LoginViewModel>, true);
            PlayCommand = new ButtonCommand(OpenAny<LoginViewModel>, true);
            _children = new ObservableCollection<object>();
            _children.Add(new ViewDeckViewModel());
            _children.Add(new PlayViewModel());
        }
        #endregion

        public ICommand PlayClick
        {
            get { return PlayCommand; }
        }
        public ICommand ViewDeckClick
        {
            get { return ViewDeckCommand; }
        }

        public ObservableCollection<object> Children { get { return _children; } }
    }
}
