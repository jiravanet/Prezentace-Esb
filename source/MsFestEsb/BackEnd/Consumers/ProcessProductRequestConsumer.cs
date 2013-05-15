using System;
using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{
	public class ProcessProductRequestConsumer: ConsumerOf<ProcessProductRequest>
	{
		readonly IServiceBus bus;
		readonly IStore store;

		public ProcessProductRequestConsumer(IServiceBus bus, IStore store)
		{
			this.bus = bus;
			this.store = store;
		}

		public void Consume(ProcessProductRequest message)
		{
			message.BookedPieces = store.BookProduct(message.OrderId, message.ProductId, message.Pieces, message.BookedPieces);
			if (message.Pieces == message.BookedPieces)
			{
				bus.Send(new ProductAddedOnOrder() { OrderId = message.OrderId, CorrelationId = message.OrderId });
			}
			else
			{
				bus.DelaySend(DateTime.Now.Add(TimeSpan.FromSeconds(30)), message);
			}
		}
	}
}