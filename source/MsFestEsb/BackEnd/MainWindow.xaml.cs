using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using BackEnd.Analytics;
using BackEnd.Interfaces;

namespace BackEnd
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : INotifyPropertyChanged
	{
		readonly IAnalyticSource source;

	    public MainWindow()
		{
			Orders = new ObservableCollection<AnalyticOrderSet>();
			InitializeComponent();
			TotalCount = 0;
		}

		public MainWindow(IAnalyticSource source): this()
		{
			this.source = source;
			this.source.Subscription.Buffer(TimeSpan.FromSeconds(10)).ObserveOnDispatcher().Subscribe(x =>
			                                                   {
			                                                       Orders.Clear();
			                                                       x.ToList().ForEach(Orders.Add);
			                                                       TotalCount += x.Count;
			                                                   });
		}

		public ObservableCollection<AnalyticOrderSet> Orders { get; set; }


		private int _totalCount;

		public int TotalCount
		{
			get { return _totalCount; }
			set
			{
				_totalCount = value;
				OnPropertyChanged(new PropertyChangedEventArgs("TotalCount"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, e);
		}
	}
}
