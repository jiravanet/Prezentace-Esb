using System;
using System.Diagnostics;
using Messages.BackEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{
	public class OrderCompletedConsumer: ConsumerOf<OrderCompleted>
	{
		public void Consume(OrderCompleted message)
		{
			//TODO: do the work needed when order is completed
			var text = string.Format("{0} {1:HH:mm:ss}", message.CorrelationId, DateTime.Now);

			Debug.WriteLine(text, "OrderCompleted");
		}
	}
}