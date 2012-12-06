using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rhino.ServiceBus.Internal;

namespace BackEnd.Installers
{
	public class ConsumersInstaller: IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.
					FromAssemblyContaining<Bootstrapper>().
					Where(type =>
					      typeof (IMessageConsumer).IsAssignableFrom(type) &&
					      !typeof (IOccasionalMessageConsumer).IsAssignableFrom(type)).
					Configure(k => k.LifestyleTransient()));
		}
	}
}