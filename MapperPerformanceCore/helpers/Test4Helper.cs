using AutoMapperLibrary;
using AutoMapperLibraryCore;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MapperPerformanceCore
{
	public class Test4Helper : ITestHelper
	{
		private ICustomMapper _customMapper;
		private List<SourceClass> _mapFrom;

		public List<KeyValuePair<string, long>> Times { get; set; }
		public List<SourceClass> Source { get => _mapFrom; set => throw new NotImplementedException(); }

		List<DestinationClass> _manualList = new List<DestinationClass>();
		List<DestinationClass> _mapperList = new List<DestinationClass>();

		public Test4Helper()
		{
			_mapFrom = new List<SourceClass>();
			Times = new List<KeyValuePair<string, long>>();

			Console.WriteLine("'SourceClass':");
			GetAllProperties(typeof(SourceClass), "   ");
			Console.WriteLine("");

			Console.WriteLine("'DestinationClass':");
			GetAllProperties(typeof(DestinationClass), "   ");
			Console.WriteLine("");
		}
		
		public void DoTest(int x)
		{
			//use automapper
			_customMapper = new CustomAutoMapper();
			DoTheCalculationsForMapper(x);

			//use tinymapper
			_customMapper = new CustomTinyMapper();
			DoTheCalculationsForMapper(x);

			//use agilemapper
			_customMapper = new CustomAgileMapper();
			DoTheCalculationsForMapper(x);

			//use mapster
			_customMapper = new CustomMapsterMapper();
			DoTheCalculationsForMapper(x);

			//TODO - use Boxed.Mapping


			//use manual mapping
			DoTheCalculationsForManualMapper(x);
		}

		public void PopulateTestData(int count)
		{
			var random = new Random();
			for (int x = 1; x < count + 1; x++)
			{
				var customer = GetCustomerFromDB(x, random);
				_mapFrom.Add(customer);
			}

			ValidateData(_mapFrom);
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

			ValidateData(_mapperList);
		}

		private void DoTheCalculationsForManualMapper(int x)
		{
			var time = TimeMethod(RunManual);
			Times.Add(new KeyValuePair<string, long>("Manual Map", time));
			ValidateData(_manualList);
		}

		private void RunManual()
		{
			_manualList = new List<DestinationClass>();
			foreach (var source in _mapFrom)
			{
				var result = HelperMapper.GetFrom(source);
				_manualList.Add(result);
			}
		}

		private void RunMapper()
		{
			_mapperList = _customMapper.Map<List<SourceClass>, List<DestinationClass>>(_mapFrom);
		}

		private void ValidateData(List<DestinationClass> destination)
		{
			if (destination[1].DestinationClassId != 2)
			{
				throw new Exception("value not filled");
			}

			if (destination[1].CalculatedValue != 4)
			{
				throw new Exception("value not filled");
			}

			if (destination[0].Children == null || destination[0].Children.Count == 0)
			{
				throw new Exception("value not filled");
			}

			if (destination[0].Children[0].DestinationNephews == null || destination[0].Children[0].DestinationNephews.Count == 0)
			{
				throw new Exception("DestinationClass.children.DestinationNephews not present");
			}

			if (string.IsNullOrEmpty(destination[0].Children[0].DestinationNephews[0].Name))
			{
				throw new Exception("SourceClass.children.DestinationNephews.name not present");
			}
		}

		private void ValidateData(List<SourceClass> sourceData)
		{
			if (sourceData[1].SourceClassId != 2)
			{
				throw new Exception("SourceClass.SourceClassId value not filled");
			}

			if (string.IsNullOrEmpty(sourceData[0].FirstName))
			{
				throw new Exception("SourceClass.FirstName value not filled");
			}

			if (string.IsNullOrEmpty(sourceData[0].LastName))
			{
				throw new Exception("SourceClass.LastName value not filled");
			}

			if (sourceData[0].Children == null || sourceData[0].Children.Count == 0)
			{
				throw new Exception("SourceClass.children not present");
			}

			if (sourceData[0].Children[0].SourceChildId == 0)
			{
				throw new Exception("SourceClass.children.SourceChildId not present");
			}

			if (sourceData[0].Children[0].SourceNephews == null || sourceData[0].Children[0].SourceNephews.Count == 0)
			{
				throw new Exception("SourceClass.children.SourceNephews not present");
			}

			if (string.IsNullOrEmpty(sourceData[0].Children[0].SourceNephews[0].FirstName))
			{
				throw new Exception("SourceClass.children.SourceNephews.FirstName not present");
			}

			if (string.IsNullOrEmpty(sourceData[0].Children[0].SourceNephews[0].LastName))
			{
				throw new Exception("SourceClass.children.SourceNephews.LastName not present");
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

		private void GetAllProperties(Type type, string separator)
		{
			var propertyInfos = type.GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				var propType = propertyInfo.PropertyType;
				if (propType.IsGenericType)
				{
					if (propType.GetGenericTypeDefinition() == typeof(List<>))
					{
						Console.WriteLine(separator + propertyInfo.Name + " (List) :");
						var t3 = propType.GetGenericArguments().First();
						GetAllProperties(t3, separator + separator);
					}
				}
				else
				{
					Console.WriteLine(separator + propertyInfo.Name + " (" + propertyInfo.PropertyType.Name + ")");
				}
			}
		}
	}
}
