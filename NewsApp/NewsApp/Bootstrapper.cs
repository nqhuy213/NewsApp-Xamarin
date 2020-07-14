using Autofac;
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
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(ViewModel)));
            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }

    }
}
