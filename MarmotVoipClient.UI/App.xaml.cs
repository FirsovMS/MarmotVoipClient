using Autofac;
using MarmotVoipClient.UI.Startup;
using System;
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
            MessageBox.Show("Unexpected Error occured." + Environment.NewLine
                + e.Exception.Message, "Unexpected error");

            e.Handled = true;
        }
    }
}
