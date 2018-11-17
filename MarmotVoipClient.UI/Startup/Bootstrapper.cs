using Autofac;
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

			// register dependieces
			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<MainViewModel>().AsSelf();
			//builder.RegisterType<ContactNavigationViewModel>().AsSelf();
			//builder.RegisterType<ContactNavigationViewModel>().AsSelf();

			return builder.Build();
		}
	}
}
