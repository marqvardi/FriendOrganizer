using Autofac;
using Autofac.Core;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.StartUp
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();


            return builder.Build();
        }
    }
}
