using Autofac;

namespace FT.Demos.CommandPattern.ConsoleCore
{
    public sealed class AutofacManager
    {
        private static ContainerBuilder _builder;

        public static IContainer GetContainer()
        {
            _builder = new ContainerBuilder();
            RegisterTypes();
            RegisterAssemblies();
            return _builder.Build();
        }

        private static void RegisterTypes()
        {
            _builder.RegisterType<PersonConfigurationApplication>().As<IApplication>();
        }

        private static void RegisterAssemblies()
        {
            _builder.RegisterModule(new CommandImplementations.AutofacModule());
            _builder.RegisterModule(new Infrastructure.AutofacModule());
        }
    }
}
