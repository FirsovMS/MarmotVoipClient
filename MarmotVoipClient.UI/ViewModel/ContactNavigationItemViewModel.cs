using MarmotVoipClient.Model;
using MarmotVoipClient.Model.Data;
using MarmotVoipClient.UI.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.ViewModel
{
	public class ContactNavigationItemViewModel : ViewModelBase
	{
		private Color colorValue;
		private string initials;
		private string firstName;
		private string lastName;
		private Message lastMessage;

		public Color Color
		{
			get { return colorValue; }
			set
			{
				colorValue = value;
				OnPropertyChanged();
			}
		}

		public string Initials
		{
			get { return initials; }
			set
			{
				initials = value;
				OnPropertyChanged();
			}
		}

		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;
				OnPropertyChanged();
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
				OnPropertyChanged();
			}
		}

		public Message LastMessage
		{
			get { return lastMessage; }
			set
			{
				lastMessage = value;
				OnPropertyChanged();
			}
		}

		public ContactNavigationItemViewModel(Contact contact, Message lastMessage)
		{

		}
	}
}
