﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FrontEnd.Installers
{
	public class ViewsInstaller: IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
            container.Register(
                Component.For<MainWindow>()
                );
		}
	}
}