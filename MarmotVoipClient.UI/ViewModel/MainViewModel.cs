using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public IContactNavigationViewModel ContactNavigation { get; }

        public IMessageDialogViewModel MessageDialogs { get; }

        public MainViewModel(IContactNavigationViewModel contactNavigation,
          IMessageDialogViewModel messageDialog)
        {
            ContactNavigation = contactNavigation;
            MessageDialogs = messageDialog;
        }

        public void Load()
        {
            ContactNavigation.Load();
        }
    }
}
