using System;
using BackEnd.Interfaces;

namespace BackEnd.Workers
{
	public class ProductStore: IStore
	{
		public int BookProduct(Guid orderId, int productId, int pieces, int bookedPieces)
		{
			if (productId == 1)
			{
				return ++bookedPieces;
			}
			return pieces;
		}

		public void SaveOrderInformation(Guid id, string customerName, DateTime date)
		{
			//TODO: save information to data store
		}
	}
}