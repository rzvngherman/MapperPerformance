using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AutoMapperLibrary;
using MapperPerformanceCore.Objects;

namespace MapperPerformanceCore
{
	public interface ITestHelper
	{
		void PopulateCustomers(int count);
		void DoTest(int x);
		List<KeyValuePair<string, long>> Times { get; set; }
	}

	public class Test1Helper : ITestHelper
	{
		private ICustomMapper _customMapper;
		private List<Customer> _customers;

		public Test1Helper()
		{
			_customers = new List<Customer>();
			Times = new List<KeyValuePair<string, long>>();

			Console.WriteLine("'Customer' -> 'CustomerViewItem'");
		}

		public List<KeyValuePair<string, long>> Times { get; set; }

		public void PopulateCustomers(int count)
		{
			var results = new List<Customer>();
			for (int x = 0; x < count; x++)
			{
				var customer = GetCustomerFromDB();
				_customers.Add(customer);
			}
		}

		private Customer GetCustomerFromDB()
		{
			return new Customer()
			{
				DateOfBirth = new DateTime(1987, 11, 2),
				FirstName = "Andriy",
				LastName = "Buday",
				NumberOfOrders = 7
			};
		}

		public void DoTest(int x)
		{
			_customMapper = new CustomAutoMapper();
			DoTheCalculationsForMapper(x);

			//use tinymapper
			_customMapper = new AutoMapperLibraryCore.TinyMapperConverters.TinyMapperConfig();
			DoTheCalculationsForMapper(x);

			//use AgileMapper
			_customMapper = new CustomAgileMapper();
			DoTheCalculationsForMapper(x);

			//use MapsterMapper
			_customMapper = new CustomMapsterMapper();
			DoTheCalculationsForMapper(x);

			//CustomBoxedMapping
			_customMapper = new CustomBoxedMapping();
			DoTheCalculationsForMapper(x);

			DoTheCalculationsForManualMapper(x);
		}

		private void DoTheCalculationsForMapper(int x)
		{
			var time = TimeMethod(RunMapper);
			//Console.WriteLine(string.Format("{0} (ms) - {1}", time, _customMapper.MapperName));

			Times.Add(new KeyValuePair<string, long>(_customMapper.MapperName, time));
		}

		private long TimeMethod(Action methodToTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			methodToTime();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}

		private void DoTheCalculationsForManualMapper(int x)
		{
			var time = TimeMethod(RunManual);
			//Console.WriteLine(string.Format("{0} (ms) - Manual Map", time));
			Times.Add(new KeyValuePair<string, long>("Manual Map", time));
		}

		private void RunMapper()
		{
			var customers = _customMapper.Map<List<Customer>, List<CustomerViewItem>>(_customers);
		}

		private void RunManual()
		{
			var customers = new List<CustomerViewItem>();
			foreach (Customer customer in _customers)
			{
				CustomerViewItem customerViewItem = new CustomerViewItem()
				{
					CustomerViewItemFirstName = customer.FirstName,
					CustomerViewItemLastName = customer.LastName,
					CustomerViewItemDateOfBirth = customer.DateOfBirth,
					CustomerViewItemNumberOfOrders = customer.NumberOfOrders,
				};

				customers.Add(customerViewItem);
			}
		}
	}
}
