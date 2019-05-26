using System;
using Autofac;
using Autofac.Core;
using Catel.Reflection;
using Microsoft.Extensions.DependencyInjection;
using IContainer = Autofac.IContainer;

namespace MovieDatabase.Common.Helpers
{
    internal static class AutoFacHelper
    {
        public static IContainer SetupContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            
            var moduleTypes = TypeCache.GetTypes(x => x.IsClassEx() && !x.IsAbstractEx() && x.ImplementsInterfaceEx<IModule>());

            foreach (var moduleType in moduleTypes)
            {
                if (Activator.CreateInstance(moduleType) is IModule module)
                {
                    builder.RegisterModule(module);
                }
            }

            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyModules(assemblies);


            var result = builder.Build();
            return result;
        }
    }
}