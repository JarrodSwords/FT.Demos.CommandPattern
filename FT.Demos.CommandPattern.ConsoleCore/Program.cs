using Autofac;

namespace FT.Demos.CommandPattern.ConsoleCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var scope = AutofacManager.GetContainer().BeginLifetimeScope())
                scope.Resolve<IApplication>().Execute();
        }
    }
}
