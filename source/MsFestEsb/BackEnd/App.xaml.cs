﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Messages.Helpers;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;

namespace BackEnd
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			//PrepareQueues.Prepare("msmq://localhost/BackEnd", QueueType.Standard);

			var container = new WindsorContainer();
			container.Install(FromAssembly.This());
			container.Resolve<IStartableServiceBus>().Start();

			var view = container.Resolve<MainWindow>();
			this.MainWindow = view;
			view.Show();

		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
		}
	}
}
