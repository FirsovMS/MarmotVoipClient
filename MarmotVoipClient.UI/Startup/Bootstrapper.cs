using Autofac;
using MarmotVoipClient.UI.Data;
using MarmotVoipClient.UI.Data.Lookups;
using MarmotVoipClient.UI.ViewModel;
using Prism.Events;

namespace MarmotVoipClient.UI.Startup
{
    public class Bootstrapper
	{
		public IContainer Bootstrap()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

			// register ViewModels
			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<MainViewModel>().AsSelf();
			builder.RegisterType<ContactNavigationViewModel>().As<IContactNavigationViewModel>();
			builder.RegisterType<MessageDialogViewModel>().As<IMessageDialogViewModel>();

			builder.RegisterType<ContactDataService>().As<IContactDataService>();
			builder.RegisterType<ContactLookupDataService>().As<IContactLookupDataService>();

			return builder.Build();
		}
	}
}
