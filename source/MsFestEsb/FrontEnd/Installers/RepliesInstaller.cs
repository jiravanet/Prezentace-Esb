using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FrontEnd.Consumers;

namespace FrontEnd.Installers
{
    public class RepliesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRepliesSource>().ImplementedBy<RepliesSource>());
        }
    }
}