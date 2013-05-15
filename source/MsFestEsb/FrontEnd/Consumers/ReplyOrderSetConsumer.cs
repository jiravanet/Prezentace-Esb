using System.Diagnostics;
using Messages.FrontEnd;
using Rhino.ServiceBus;

namespace FrontEnd.Consumers
{
	public class ReplyOrderSetConsumer: ConsumerOf<ReplyOrderSet>
	{
	    readonly IRepliesSource replies;

	    public ReplyOrderSetConsumer(IRepliesSource replies)
	    {
	        this.replies = replies;
	    }

	    public void Consume(ReplyOrderSet message)
		{
            replies.Add(message);
			Debug.WriteLine(message.Id, "ReplyOrderSet");
		}
	}
}