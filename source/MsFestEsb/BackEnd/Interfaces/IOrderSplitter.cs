using Messages.BackEnd;

namespace BackEnd.Interfaces
{
	public interface IOrderSplitter
	{
		ProcessProductRequest[] Split(OrderCreated message);
	}
}