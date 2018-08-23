using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels.TabControlVM
{
   public class TabControlViewModel: BaseViewModel
    {

        public class ViewDeckViewModel:TabControlViewModel
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

        public class PlayViewModel
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
    }
}
