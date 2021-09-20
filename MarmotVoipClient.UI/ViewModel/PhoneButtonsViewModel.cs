using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.ViewModel
{
    public class PhoneButtonsViewModel
    {
        private string _phoneNumber = String.Empty;

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber += value;
            }
        }


    }
}
