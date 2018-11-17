using MarmotVoipClient.UI.ViewModel;
using System.Windows;

namespace MarmotVoipClient.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private readonly MainViewModel viewModel;

		public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

			this.viewModel = viewModel;
			DataContext = this.viewModel;

			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			viewModel.Load();
		}
	}
}
