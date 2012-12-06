﻿using System;

namespace Messages
{
	[Serializable]
	public abstract class BaseMessage
	{
		protected BaseMessage()
		{
			Id = Guid.NewGuid();
		}

		public BaseMessage(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; set; }

		public override string ToString()
		{
			return String.Format("{0}; Id={1};", GetType(), Id);
		}
	}
}