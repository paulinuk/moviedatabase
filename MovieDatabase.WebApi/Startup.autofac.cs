using System;
using System.Diagnostics;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Catel.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MovieDatabase.WebApi
{
    public partial class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IContainer ConfigureAutofac(IServiceCollection services)
        {
            var container = ConfigureContainer(services);

            ApplicationContainer = container;

            return container;
        }


        private IContainer ConfigureContainer(IServiceCollection services)
        {
            if (ApplicationContainer == null)
            {
                var builder = new ContainerBuilder();
                // Generic registrations
                try
                {
                    var moduleTypes = TypeCache.GetTypes(x =>
                        x.IsClassEx() && !x.IsAbstractEx() && x.ImplementsInterfaceEx<IModule>());

                    foreach (var moduleType in moduleTypes)
                    {
                        if (Activator.CreateInstance(moduleType) is IModule module)
                        {
                            builder.RegisterModule(module);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }

                services.AddAutofac();

                // Some fixed types
                builder.Populate(services);

                ApplicationContainer = builder.Build();

                var serviceProvider = new AutofacServiceProvider(ApplicationContainer);
            }

            return ApplicationContainer;
        }

        partial void ConfigureAutofacForWebApi(ContainerBuilder builder);

    }
}