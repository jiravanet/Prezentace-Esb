using System;
using System.Reactive.Subjects;
using BackEnd.Interfaces;

namespace BackEnd.Analytics
{
	public class AnalyticsSource: IAnalyticSource
	{
		readonly Subject<AnalyticOrderSet> subject;

		public AnalyticsSource()
		{
			subject = new Subject<AnalyticOrderSet>();
		}

		public void Add(AnalyticOrderSet data)
		{
			subject.OnNext(data);
		}

		public IObservable<AnalyticOrderSet> Subscription
		{
			get { return subject; }
		} 
	}
}