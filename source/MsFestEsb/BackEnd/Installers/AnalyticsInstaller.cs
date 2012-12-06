using BackEnd.Analytics;
using BackEnd.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BackEnd.Installers
{
	public class AnalyticsInstaller: IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IAnalyticSource>().ImplementedBy<AnalyticsSource>().LifestyleSingleton()
				);
		}
	}
}