﻿using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace FrontEnd
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IServiceBus _bus;
		private int _counter;
		public MainWindow()
		{
			InitializeComponent();
			_counter = 0;
		}

		public MainWindow(IServiceBus bus): this()
		{
			_bus = bus;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var order = CreateOrder();
			_bus.Send(order);
		}

		private void Button_Click1000(object sender, RoutedEventArgs e)
		{
			var interval = Observable.Interval(TimeSpan.FromMilliseconds(200)).Take(100);

			var subscription = interval.SubscribeOn(NewThreadScheduler.Default).
				Subscribe(_ =>
				          {
				          	var order = CreateOrder();
				          	_bus.Send(order);
				          });
		}

		private OrderSet CreateOrder()
		{
			var result = new OrderSet();
			result.CustomerName = string.Format("Jarda {0}", _counter++);
			result.Date = DateTime.Now;
			result.OrderItems = new List<OrderItem>();
			result.OrderItems.Add(new OrderItem() { Product = 1, Pieces = 2});
			result.OrderItems.Add(new OrderItem() { Product = 2, Pieces = 3 });
			result.OrderItems.Add(new OrderItem() { Product = 3, Pieces = 1 });
			return result;
		}
	}
}
