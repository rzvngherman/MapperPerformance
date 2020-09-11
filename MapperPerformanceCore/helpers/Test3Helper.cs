using AutoMapperLibrary;
using AutoMapperLibraryCore;
using MapperPerformanceCore.Objects;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MapperPerformanceCore
{
	public class Test3Helper : ITestHelper
	{
		private List<MapFrom> _mapFrom;
		private ICustomMapper _customMapper;

		public Test3Helper()
		{
			_mapFrom = new List<MapFrom>();
			Times = new List<KeyValuePair<string, long>>();
			Console.WriteLine("'MapFrom' -> 'MapTo'");
		}

		public List<KeyValuePair<string, long>> Times { get; set; }

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

		private void RunMapper()
		{
			var customers = _customMapper.Map<List<MapFrom>, List<MapTo>>(_mapFrom);
		}

		private void DoTheCalculationsForManualMapper(int x)
		{
			var time = TimeMethod(RunManual);
			//Console.WriteLine(string.Format("{0} (ms) - Manual Map", time));
			Times.Add(new KeyValuePair<string, long>("Manual Map", time));
		}

		private long TimeMethod(Action methodToTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			methodToTime();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}

		private void RunManual()
		{
			var customers = new List<MapTo>();
			foreach (var source in _mapFrom)
			{
				var result = HelperMapper.GetFrom(source);
				customers.Add(result);
			}
		}

		public void PopulateCustomers(int count)
		{
			var random = new Random();
			var results = new List<MapFrom>();
			for (int x = 0; x < count; x++)
			{
				var customer = GetCustomerFromDB(x, random);
				_mapFrom.Add(customer);
			}
		}

		private MapFrom GetCustomerFromDB(int i, Random random)
		{
			var result = HelperMapper.GenerateTestData(i, random);
			return result;			
		}
	}
}
