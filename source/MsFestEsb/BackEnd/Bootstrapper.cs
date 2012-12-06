﻿using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor.Installer;
using Rhino.ServiceBus.Castle;

namespace BackEnd
{
	public class Bootstrapper: CastleBootStrapper
	{

		protected override void ConfigureContainer()
		{
			Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));
			Container.Install(FromAssembly.This());

			base.ConfigureContainer();
		}
	}
}