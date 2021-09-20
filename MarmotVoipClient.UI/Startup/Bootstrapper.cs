using Autofac;
using MarmotVoipClient.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            // create container
            var builder = new ContainerBuilder();

            //todo: register events

            //todo: register DbContext

            // register dependieces
            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();
            
            //todo: register all viewModels


            //todo: register services

            return builder.Build();
        }
    }
}
