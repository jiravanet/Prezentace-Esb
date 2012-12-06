using System;
using Rhino.ServiceBus.Sagas;

namespace Messages.BackEnd
{
	[Serializable]
	public class OrderCompleted : BaseMessage, ISagaMessage
	{
		public Guid OrderId { get; set; }

		public Guid CorrelationId { get; set; }
	}
}