using System;
using BackEnd.Analytics;

namespace BackEnd.Interfaces
{
	public interface IAnalyticSource
	{
		void Add(AnalyticOrderSet data);

		IObservable<AnalyticOrderSet> Subscription { get; }
	}
}