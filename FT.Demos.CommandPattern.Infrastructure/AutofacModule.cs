using Autofac;
using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new MockPersonRepository1()).As<IPersonRepository>();
        }
    }
}
