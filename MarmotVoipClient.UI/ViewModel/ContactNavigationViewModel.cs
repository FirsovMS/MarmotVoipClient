using MarmotVoipClient.Model;
using MarmotVoipClient.UI.Data;
using MarmotVoipClient.UI.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MarmotVoipClient.UI.ViewModel
{
	public class ContactNavigationViewModel : ViewModelBase, IContactNavigationViewModel
	{
		private IContactLookupDataService contactDataService;
		private IEventAggregator eventAggregator;
		private string searchText;
		private ObservableCollection<ContactNavigationItemViewModel> contacts;
		private ContactNavigationItemViewModel selectedContact;

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

		public ContactNavigationItemViewModel SelectedContact
		{
			get { return selectedContact; }
			set
			{
				selectedContact = value;
				OnPropertyChanged();
				if (selectedContact != null)
				{
					eventAggregator.GetEvent<OpenMessageDialogViewEvent>()
						.Publish(selectedContact.Id);
				}
			}
		}

		public ICommand MenuCommand { get; }

		public ContactNavigationViewModel(IContactLookupDataService contactDataService,
			IEventAggregator eventAggregator)
		{
			this.contactDataService = contactDataService;
			this.eventAggregator = eventAggregator;
			Contacts = new ObservableCollection<ContactNavigationItemViewModel>();
			MenuCommand = new DelegateCommand(OnMenuCommandExecute);
		}

		public void Load()
		{
			var lookups = contactDataService.GetLookups();

			Contacts.Clear();
			foreach (var item in lookups)
			{
				Contacts.Add(new ContactNavigationItemViewModel(item.Id, item.DisplayMember));
			}
		}

		private void OnMenuCommandExecute()
		{
			throw new NotImplementedException();
		}
	}
}
