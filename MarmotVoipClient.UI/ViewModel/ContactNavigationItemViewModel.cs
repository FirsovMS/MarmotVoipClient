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
	public class UserItemViewModel : ViewModelBase
	{
		private string displayMember;

		public Color Color { get; }

		public int Id { get; }

		public string DisplayMember
		{
			get { return displayMember; }
			set
			{
				displayMember = value;
				OnPropertyChanged();
			}
		}

		public UserItemViewModel(int id, string displayMember)
		{
			Id = id;
			DisplayMember = displayMember;
		}
	}
}
