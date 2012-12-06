﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BackEnd.Analytics;
using BackEnd.Interfaces;

namespace BackEnd
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private readonly IAnalyticSource _source;
		private int _id;

		public MainWindow()
		{
			Orders = new ObservableCollection<AnalyticOrderSet>();
			InitializeComponent();
			TotalCount = 0;
			_id = Thread.CurrentThread.ManagedThreadId;
		}

		public MainWindow(IAnalyticSource source): this()
		{
			_source = source;
			_source.Subscription.Buffer(TimeSpan.FromSeconds(10)).ObserveOn(SynchronizationContext.Current).Subscribe(x =>
			                                                   {
																													 if (_id == Dispatcher.CurrentDispatcher.Thread.ManagedThreadId)
																													 {
																													 	Orders.Clear();
																													 	x.ToList().ForEach(Orders.Add);
																													 	TotalCount += x.Count;
																													 }
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
