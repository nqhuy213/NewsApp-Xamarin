using Autofac;
using NewsApp.Services;
using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<NewsService>();
            containerBuilder.RegisterType<MainShell>();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(ViewModel)));
            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }

    }
}
