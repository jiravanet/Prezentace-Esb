using System;
using System.Reactive.Subjects;
using Messages.FrontEnd;

namespace FrontEnd.Consumers
{
    public class RepliesSource : IRepliesSource
    {
        Subject<ReplyOrderSet> replies;

        public RepliesSource()
        {
            replies = new Subject<ReplyOrderSet>();
        }

        public void Add(ReplyOrderSet order)
        {
            replies.OnNext(order);
        }

        public IObservable<ReplyOrderSet> Replies { get { return replies; } }
    }
}