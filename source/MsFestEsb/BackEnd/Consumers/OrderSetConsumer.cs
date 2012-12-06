using BackEnd.Interfaces;
using Messages.BackEnd;
using Messages.FrontEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{
	public class OrderSetConsumer: ConsumerOf<OrderSet>
	{
		private readonly IServiceBus _bus;
		private readonly IStore _store;

		public OrderSetConsumer(IServiceBus bus, IStore store)
		{
			_bus = bus;
			_store = store;
		}

		public void Consume(OrderSet message)
		{
			_store.SaveOrderInformation(message.Id, message.CustomerName, message.Date);
			_bus.Send(new OrderCreated() {OrderItems = message.OrderItems});
			_bus.Reply(new ReplyOrderSet());
		}
	}
}