﻿using BackEnd.Interfaces;
using BackEnd.Workers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas.Persisters;

namespace BackEnd.Installers
{
	public class WorkersInstaller: IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For(typeof(ISagaPersister<>)).ImplementedBy(typeof(InMemorySagaPersister<>)),
				Component.For<IStore>().ImplementedBy<ProductStore>().LifestyleSingleton(),
				Component.For<IOrderSplitter, IOrderCompleter>().ImplementedBy<OrderProcessor>().LifestyleTransient()
				);
		}
	}
}