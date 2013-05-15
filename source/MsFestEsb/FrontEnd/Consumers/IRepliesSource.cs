using System;
using Messages.FrontEnd;

namespace FrontEnd.Consumers
{
    public interface IRepliesSource
    {
        void Add(ReplyOrderSet order);

        IObservable<ReplyOrderSet> Replies { get; }
    }
}