﻿using System;

namespace Messages.BackEnd
{

	[Serializable]
	public class ProcessProductRequest: BaseMessage
	{
		public Guid OrderId { get; set; }

		public int ProductId { get; set; }

		public int Pieces { get; set; }

		public int BookedPieces { get; set; }
	}
}