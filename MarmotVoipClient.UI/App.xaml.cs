using Autofac;
using LoggingAPI;
using MarmotVoipClient.UI.Startup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MarmotVoipClient.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			// load bootstraper
			var bootrstrapper = new Bootstrapper();
			var container = bootrstrapper.Bootstrap();

			var mainWindow = container.Resolve<MainWindow>();
			MainWindow.Show();
		}

		private void Application_DispatcherUnhandledException(object sender,
			System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			Logger.Error(description: "Unexpected Error occured", exception: e.Exception, logLevel: Level.Fatal);

			MessageBox.Show("Unexpected Error occured. See the log inforamtion.", "Unexpected error");

			e.Handled = true;
		}
	}
}
