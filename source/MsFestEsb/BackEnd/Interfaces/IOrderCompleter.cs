using System.Collections.Generic;
using Messages.BackEnd;

namespace BackEnd.Interfaces
{
	public interface IOrderCompleter
	{
		OrderCompleted Complete(List<ProductAddedOnOrder> products);
	}
}