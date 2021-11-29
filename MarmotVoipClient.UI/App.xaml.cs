using Autofac;
using LoggingAPI;
using MarmotVoipClient.UI.Startup;
using System;
using System.Windows;
using System.Windows.Threading;

namespace MarmotVoipClient.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IContainer _container;

        public static IContainer Container { get => _container; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootrstrapper = new Bootstrapper();
            _container = bootrstrapper.Bootstrap();

            try
            {
                var mainWindow = _container.Resolve<MainWindow>();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                Logger.Error(description: "MainWindow not created!", exception: ex, logLevel: Level.Fatal);
                MessageBox.Show("Application not created! See log file for more information", "Startup Error");
                Current.Shutdown();
            }
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Error(description: "Unexpected Error occured", exception: e.Exception, logLevel: Level.Fatal);

            MessageBox.Show("Unexpected Error occured. See the log inforamtion.", "Unexpected error");

            e.Handled = true;
        }
    }
}
