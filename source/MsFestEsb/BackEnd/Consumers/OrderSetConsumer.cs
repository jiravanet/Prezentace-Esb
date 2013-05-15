using BackEnd.Interfaces;
using Messages.BackEnd;
using Messages.FrontEnd;
using Rhino.ServiceBus;

namespace BackEnd.Consumers
{
	public class OrderSetConsumer: ConsumerOf<OrderSet>
	{
		readonly IServiceBus bus;
		readonly IStore store;

		public OrderSetConsumer(IServiceBus bus, IStore store)
		{
			this.bus = bus;
			this.store = store;
		}

		public void Consume(OrderSet message)
		{
			store.SaveOrderInformation(message.Id, message.CustomerName, message.Date);
			bus.Send(new OrderCreated() {OrderItems = message.OrderItems});
			bus.Reply(new ReplyOrderSet());
		}
	}
}