using System;
using System.Diagnostics;
using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Sagas;

namespace BackEnd.Consumers
{
	public class OrderProcessingSaga: 
		ISaga<OrderState>,
		InitiatedBy<OrderSplitted>,
		Orchestrates<ProductAddedOnOrder>,
		Orchestrates<OrderTimeout>
	{
		private readonly IServiceBus _bus;
		private readonly IOrderCompleter _completer;

		public OrderProcessingSaga(IServiceBus bus, IOrderCompleter completer)
		{
			_bus = bus;
			_completer = completer;
			State = new OrderState();
		}

		public void Consume(OrderSplitted message)
		{
			State.Items = message.Length;
			_bus.DelaySend(DateTime.Now.Add(TimeSpan.FromSeconds(50)), new OrderTimeout() { CorrelationId = message.CorrelationId, OrderId = message.CorrelationId });
		}

		public void Consume(ProductAddedOnOrder message)
		{
			State.AddProduct(message);
			if (State.IsComplete)
			{
				OnAllProductsAdded(_completer.Complete(State.Products));
			}

		}

		public void Consume(OrderTimeout message)
		{
			//_bus.Send(new );
			IsCompleted = true;
			Debug.WriteLine("Order timeout");
		}

		private void OnAllProductsAdded(OrderCompleted message)
		{
			message.CorrelationId = Id;
			_bus.Send(message);
			IsCompleted = true;
		}

		public Guid Id { get; set; }

		public bool IsCompleted { get; set; }

		public OrderState State { get; set; }
	}
}