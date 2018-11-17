using MarmotVoipClient.Model;
using MarmotVoipClient.UI.Data;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MarmotVoipClient.UI.ViewModel
{
	public class ContactNavigationViewModel : ViewModelBase
	{
		private IContactLookupDataService contactDataService;
		private IEventAggregator eventAggregator;
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

		public ICommand MenuCommand { get; }

		public ContactNavigationViewModel(IContactLookupDataService contactDataService,
			IEventAggregator eventAggregator)
		{
			this.contactDataService = contactDataService;
			this.eventAggregator = eventAggregator;

			MenuCommand = new DelegateCommand(OnMenuCommandExecute);
		}

		public void Load()
		{
			var lookups = contactDataService.GetLookups();
			foreach (var item in lookups)
			{

			}
		}

		private void OnMenuCommandExecute()
		{
			throw new NotImplementedException();
		}
	}
}
