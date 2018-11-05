using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarmotVoipClient.DataAccess
{
	public abstract class DataObjectBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
