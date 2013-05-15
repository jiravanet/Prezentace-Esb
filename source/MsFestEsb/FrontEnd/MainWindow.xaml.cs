using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Windows;
using FrontEnd.Consumers;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace FrontEnd
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private readonly IServiceBus bus;
	    readonly IRepliesSource source;
	    private int counter;
	    readonly Subject<OrderSet> orders;
		public MainWindow()
		{
			InitializeComponent();
			counter = 0;
            orders = new Subject<OrderSet>();
		    orders.ObserveOn(SynchronizationContext.Current).Subscribe(x => _items.Items.Add(x));
		}

		public MainWindow(IServiceBus bus, IRepliesSource source): this()
		{
		    this.bus = bus;
		    source.Replies.ObserveOnDispatcher().Subscribe(x => _items.Items.Add(x));
		}

	    private void Button_Click(object sender, RoutedEventArgs e)
		{
		    SendOrder();
		}

	    private void Button_Click1000(object sender, RoutedEventArgs e)
	    {
	        var interval = Observable.Interval(TimeSpan.FromMilliseconds(200)).Take(10);
	        interval.SubscribeOn(NewThreadScheduler.Default).Subscribe(_ => SendOrder());
	    }

	    void SendOrder()
	    {
	        var order = CreateOrder();
	        orders.OnNext(order);
	        bus.Send(order);
	    }

	    private OrderSet CreateOrder()
		{
			var result = new OrderSet
			    {
			        CustomerName = string.Format("Jarda {0}", counter++),
			        Date = DateTime.Now,
			        OrderItems =
			            new List<OrderItem>
			                {
			                    new OrderItem() { Product = 1, Pieces = 2 },
			                    new OrderItem() { Product = 2, Pieces = 3 },
			                    new OrderItem() { Product = 3, Pieces = 1 }
			                }
			    };
	        return result;
		}
	}
}
