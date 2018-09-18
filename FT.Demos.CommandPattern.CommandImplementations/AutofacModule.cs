using Autofac;
using FT.Demos.CommandPattern.CommandImplementations.Domain;
using FT.Demos.CommandPattern.Services;

namespace FT.Demos.CommandPattern.CommandImplementations
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new BasicCommandStack()).As<ICommandStack>();

            builder.RegisterType<PersonConfigurationService>().As<IPersonConfigurationService>();
        }
    }
}
