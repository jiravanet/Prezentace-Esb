﻿using System.Diagnostics;
using Messages.FrontEnd;
using Rhino.ServiceBus;

namespace FrontEnd.Consumers
{
	public class ReplyOrderSetConsumer: ConsumerOf<ReplyOrderSet>
	{
		public void Consume(ReplyOrderSet message)
		{
			Debug.WriteLine(message.Id, "ReplyOrderSet");
		}
	}
}