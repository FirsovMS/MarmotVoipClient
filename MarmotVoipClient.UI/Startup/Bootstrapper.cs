using Autofac;
using DAL;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model.Data;
using MarmotVoipClient.UI.Data;
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

			// register database context
			builder.RegisterType<DataAccessLayer>().AsSelf().SingleInstance();
			builder.RegisterType<ContactsDAO>().As<IBaseActions<Contact>>().SingleInstance();

			// register ViewModels
			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<MainViewModel>().AsSelf();
			builder.RegisterType<ContactNavigationViewModel>().As<IContactNavigationViewModel>();
			builder.RegisterType<MessageDialogViewModel>().As<IMessageDialogViewModel>();

			builder.RegisterType<ContactDataService>().AsImplementedInterfaces();
			builder.RegisterType<ContactLookupDataService>().AsImplementedInterfaces();

			return builder.Build();
		}
	}
}
