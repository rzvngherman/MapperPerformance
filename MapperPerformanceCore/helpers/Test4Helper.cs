using AutoMapperLibrary;
using AutoMapperLibraryCore;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MapperPerformanceCore
{
	public class Test4Helper : ITestHelper
	{
		private ICustomMapper _customMapper;
		private List<SourceClass> _mapFrom;

		public List<KeyValuePair<string, long>> Times { get; set; }
		public List<SourceClass> Source { get => _mapFrom; set => throw new NotImplementedException(); }


		public Test4Helper()
		{
			_mapFrom = new List<SourceClass>();
			Times = new List<KeyValuePair<string, long>>();
			Console.WriteLine("'SourceClass' -> 'DestinationClass'");
		}

		public void DoTest(int x)
		{
			_customMapper = new CustomAutoMapper();
			DoTheCalculationsForMapper(x);

			//use tinymapper
			_customMapper = new CustomTinyMapper();
			DoTheCalculationsForMapper(x);

			DoTheCalculationsForManualMapper(x);
		}

		public void PopulateCustomers(int count)
		{
			var random = new Random();
			var results = new List<SourceClass>();
			for (int x = 1; x < count + 1; x++)
			{
				var customer = GetCustomerFromDB(x, random);
				_mapFrom.Add(customer);
			}
		}

		private SourceClass GetCustomerFromDB(int i, Random random)
		{
			var result = HelperMapper.GenerateTestData2(i, random);
			return result;
		}

		private void DoTheCalculationsForMapper(int x)
		{
			var time = TimeMethod(RunMapper);
			Times.Add(new KeyValuePair<string, long>(_customMapper.MapperName, time));
		}

		private void DoTheCalculationsForManualMapper(int x)
		{
			var time = TimeMethod(RunManual);
			Times.Add(new KeyValuePair<string, long>("Manual Map", time));
		}

		private void RunManual()
		{
			var customers = new List<DestinationClass>();
			foreach (var source in _mapFrom)
			{
				var result = HelperMapper.GetFrom(source);
				customers.Add(result);
			}
		}

		private void RunMapper()
		{
			var customers = _customMapper.Map<List<SourceClass>, List<DestinationClass>>(_mapFrom);

			//to be sure that data is filled !
			if (customers[1].DId != 2)
			{
				throw new Exception("value not filled");
			}

			if (customers[1].CalculatedValue != 4)
			{
				throw new Exception("value not filled");
			}
		}

		private long TimeMethod(Action methodToTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			methodToTime();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
	}
}
