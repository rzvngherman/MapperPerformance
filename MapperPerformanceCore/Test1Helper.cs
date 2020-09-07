﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AutoMapperLibrary;
using MapperPerformanceCore.Objects;

namespace MapperPerformanceCore
{
	public class Test1Helper
	{
		private ICustomMapper _customMapper;
		private List<Customer> _customers;

		public Test1Helper()
		{
			_customers = new List<Customer>();
		}

		internal void PopulateCustomers(int count)
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

		internal void DoTest(int x)
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
			_customMapper.CreateMap<List<Customer>, List<CustomerViewItem>>();

			Console.WriteLine(string.Format("{0} (ms) - {1}", TimeMethod(RunMapper), _customMapper.MapperName));
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
			Console.WriteLine(string.Format("{0} (ms) - Manual Map", TimeMethod(RunManual)));
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
					FirstName = customer.FirstName,
					LastName = customer.LastName,
					DateOfBirth = customer.DateOfBirth,
					NumberOfOrders = customer.NumberOfOrders,
				};

				customers.Add(customerViewItem);
			}
		}
	}
}
