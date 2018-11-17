using MahApps.Metro.IconPacks;
using MarmotVoipClient.Model.Data;
using MarmotVoipClient.UI.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MarmotVoipClient.UI.ViewModel
{
	public class MessageDialogViewModel : ViewModelBase, IMessageDialogViewModel
	{
		private IEventAggregator eventAggregator;
		private ObservableCollection<Message> messages;
		private Message selectedMessage;
		private PackIconMaterial iconSend;
		private string messageText;

		public ObservableCollection<Message> Messages
		{
			get { return messages; }
			set
			{
				messages = value;
				OnPropertyChanged();
			}
		}

		public Message SelectedMessage
		{
			get { return selectedMessage; }
			set
			{
				selectedMessage = value;
				OnPropertyChanged();
			}
		}

		public string MessageText
		{
			get { return messageText; }
			set
			{
				messageText = value;
				OnPropertyChanged();
				UpdateSendIcon();
			}
		}

		public PackIconMaterial IconSend
		{
			get { return iconSend; }
			set
			{
				iconSend = value;
				OnPropertyChanged();
			}
		}

		public ICommand BackCommand { get; }

		public ICommand CallCommand { get; }

		public ICommand SearchCommand { get; }

		public ICommand PropertiesCommand { get; }

		public ICommand SendCommand { get; }

		public ICommand ContectInfoCommand { get; }

		public MessageDialogViewModel(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;

			IconSend = new PackIconMaterial()
			{
				Kind = PackIconMaterialKind.Microphone
			};

			BackCommand = new DelegateCommand(OnBackCommandExecute);
			CallCommand = new DelegateCommand(OnCallCommandExecute);
			SearchCommand = new DelegateCommand(OnSearchCommandExecute);
			PropertiesCommand = new DelegateCommand(OnPropertiesCommandExecute);
			SendCommand = new DelegateCommand(OnSendCommandExecute);
			ContectInfoCommand = new DelegateCommand(OnUserInfoCommandExecute);

			eventAggregator.GetEvent<OpenMessageDialogViewEvent>()
				.Subscribe(AfterOpenMessageDialog);
		}

		// TODO: Implement load stored in database messages
		public void Load(int contactId)
		{
			throw new NotImplementedException();
		}

		private void OnUserInfoCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnSendCommandExecute()
		{
			throw new NotImplementedException();
		}

		// TODO: Load contact messages
		private void AfterOpenMessageDialog(int contactId)
		{
			throw new NotImplementedException();
		}

		private void UpdateSendIcon()
		{
			if (!string.IsNullOrWhiteSpace(messageText))
			{
				IconSend = new PackIconMaterial()
				{
					Kind = PackIconMaterialKind.Send
				};
			}
			else
			{
				IconSend = new PackIconMaterial()
				{
					Kind = PackIconMaterialKind.Microphone
				};
			}
		}

		private void OnPropertiesCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnSearchCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnCallCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnBackCommandExecute()
		{
			throw new NotImplementedException();
		}
	}
}
