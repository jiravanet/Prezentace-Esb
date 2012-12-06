using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Impl;

namespace FrontEnd.Installers
{
	public class RhinoEsbInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			new RhinoServiceBusConfiguration().UseCastleWindsor(container).Configure();
		}
	}
}