using System;
using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Sagas;

namespace BackEnd.Consumers
{
	public class OrderProcessingConsumer: 
		ISaga<OrderState>,
		InitiatedBy<OrderSplitted>,
		Orchestrates<ProductAddedOnOrder>
	{
		private readonly IServiceBus _bus;
		private readonly IOrderCompleter _completer;

		public OrderProcessingConsumer(IServiceBus bus, IOrderCompleter completer)
		{
			_bus = bus;
			_completer = completer;
			State = new OrderState();
		}

		public void Consume(OrderSplitted message)
		{
			State.Items = message.Length;
		}

		public void Consume(ProductAddedOnOrder message)
		{
			State.AddProduct(message);
			if (State.IsComplete)
			{
				OnAllProductsAdded(_completer.Complete(State.Products));
			}

		}

		private void OnAllProductsAdded(OrderCompleted message)
		{
			_bus.Send(message);
			IsCompleted = true;
		}

		public Guid Id { get; set; }

		public bool IsCompleted { get; set; }

		public OrderState State { get; set; }
	}
}