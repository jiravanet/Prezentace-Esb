using System;
using Rhino.ServiceBus.Sagas;

namespace Messages.BackEnd
{
	public class OrderTimeout: BaseMessage, ISagaMessage
	{
		public Guid OrderId { get; set; }

		public Guid CorrelationId { get; set; }
	}
}