using System.Collections.Generic;
using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{

	public class OrderCreatedConsumer: ConsumerOf<OrderCreated>
	{
		private readonly IServiceBus _bus;
		private readonly IOrderSplitter _splitter;

		public OrderCreatedConsumer(IServiceBus bus, IOrderSplitter splitter)
		{
			_bus = bus;
			_splitter = splitter;
		}

		public void Consume(OrderCreated message)
		{
			var parts = _splitter.Split(message);
			_bus.Notify(new OrderSplitted(message.Id, parts.Length) { CorrelationId = message.Id});
			_bus.Send(parts);
		}
	}
}