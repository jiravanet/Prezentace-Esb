﻿using System;
using BackEnd.Interfaces;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{
	public class ProcessProductRequestConsumer: ConsumerOf<ProcessProductRequest>
	{
		private readonly IServiceBus _bus;
		private readonly IStore _store;

		public ProcessProductRequestConsumer(IServiceBus bus, IStore store)
		{
			_bus = bus;
			_store = store;
		}

		public void Consume(ProcessProductRequest message)
		{
			message.BookedPieces = _store.BookProduct(message.OrderId, message.ProductId, message.Pieces, message.BookedPieces);
			if (message.Pieces == message.BookedPieces)
			{
				_bus.Send(new ProductAddedOnOrder() { OrderId = message.OrderId, CorrelationId = message.OrderId });
			}
			else
			{
				_bus.DelaySend(DateTime.Now.Add(TimeSpan.FromSeconds(30)), message);
			}
		}
	}
}