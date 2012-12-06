using System;

namespace BackEnd.Interfaces
{
	public interface IStore
	{
		int BookProduct(Guid orderId, int productId, int pieces, int bookedPieces);
		void SaveOrderInformation(Guid id, string customerName, DateTime date);
	}
}