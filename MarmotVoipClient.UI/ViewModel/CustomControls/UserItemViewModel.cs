using MarmotVoipClient.Model.Data;
using System.Drawing;

namespace MarmotVoipClient.UI.ViewModel.CustomControls
{
	public class UserItemViewModel : ViewModelBase
	{
		private Contact contactValue;
		private Color colorValue;
		private string initialsValue;
		private string profileNameValue;
		private string message;

		public Contact Contact
		{
			get { return contactValue; }
			set
			{
				contactValue = value;
				OnPropertyChanged();
			}
		}

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
			get { return initialsValue; }
			set
			{
				initialsValue = value;
				OnPropertyChanged();
			}
		}

		public string ProfileName
		{
			get { return profileNameValue; }
			set
			{
				profileNameValue = value;
				OnPropertyChanged();
			}
		}

		public string Message
		{
			get { return message; }
			set
			{
				message = value;
				OnPropertyChanged();
			}
		}

		public UserItemViewModel(Contact contact, string message)
		{
			Contact = contact;
			Message = message;
		}
	}
}
