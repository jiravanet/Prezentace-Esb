using System.Collections.Generic;
using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{

	public class OrderCreatedConsumer: ConsumerOf<OrderCreated>
	{
		readonly IServiceBus bus;
		readonly IOrderSplitter splitter;

		public OrderCreatedConsumer(IServiceBus bus, IOrderSplitter splitter)
		{
			this.bus = bus;
			this.splitter = splitter;
		}

		public void Consume(OrderCreated message)
		{
			var parts = splitter.Split(message);
			bus.Notify(new OrderSplitted(message.Id, parts.Length) { CorrelationId = message.Id});
			bus.Send(parts);
		}
	}
}