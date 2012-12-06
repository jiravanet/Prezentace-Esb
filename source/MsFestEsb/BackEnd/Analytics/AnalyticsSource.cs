using System;
using System.Reactive.Subjects;
using BackEnd.Interfaces;

namespace BackEnd.Analytics
{
	public class AnalyticsSource: IAnalyticSource
	{
		private readonly Subject<AnalyticOrderSet> _subject;

		public AnalyticsSource()
		{
			_subject = new Subject<AnalyticOrderSet>();
		}

		public void Add(AnalyticOrderSet data)
		{
			_subject.OnNext(data);
		}

		public IObservable<AnalyticOrderSet> Subscription
		{
			get { return _subject; }
		} 
	}
}