using MarmotVoipClient.Model;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MarmotVoipClient.UI.ViewModel
{
	public class ContactNavigationViewModel : ViewModelBase
	{
		private string searchText;
		private ObservableCollection<ContactNavigationItemViewModel> contacts;

		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged();
				// TODO: Drop event -> search text on contacts and messages
			}
		}

		public ObservableCollection<ContactNavigationItemViewModel> Contacts
		{
			get { return contacts; }
			set
			{
				contacts = value;
				OnPropertyChanged();
			}
		}

		private ContactNavigationItemViewModel selectedContact;

		public ContactNavigationItemViewModel SelectedContact
		{
			get { return selectedContact; }
			set
			{
				selectedContact = value;
				OnPropertyChanged();
				if (selectedContact != null)
				{
					
				}
			}
		}

		public void Load()
		{

		}

		public ICommand MenuCommand { get; }

		public ContactNavigationViewModel(IEventAggregator eventAggregator)
		{
			MenuCommand = new DelegateCommand(OnMenuCommandExecute);
		}

		private void OnMenuCommandExecute()
		{
			throw new NotImplementedException();
		}
	}
}
