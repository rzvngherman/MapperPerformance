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
		private readonly List<SourceClass> _mapFrom;

		public List<KeyValuePair<string, long>> Times { get; set; }
		public List<SourceClass> Source { get => _mapFrom; set => throw new NotImplementedException(); }

		private List<DestinationClass> _mapTo = new List<DestinationClass>();

		public Test4Helper(int nrOfRows)
		{
			var testDataHelper = new TestDataHelper(nrOfRows);
			_mapFrom = testDataHelper.PopulateTestData();
			ValidateData();

			Times = new List<KeyValuePair<string, long>>();
		}
		
		public void DoTest()
		{
			//use automapper
			_customMapper = new CustomAutoMapper();
			DoTheCalculationsForMapper();

			//use tinymapper
			_customMapper = new CustomTinyMapper();
			DoTheCalculationsForMapper();

			//use agilemapper
			_customMapper = new CustomAgileMapper();
			DoTheCalculationsForMapper();

			//use mapster
			_customMapper = new CustomMapsterMapper();
			DoTheCalculationsForMapper();

			//use Boxed.Mapping
			_customMapper = new CustomBoxedMapping();
			DoTheCalculationsForMapper();

			//use manual mapping
			DoTheCalculationsForManualMapper();
		}		

		private void DoTheCalculationsForMapper()
		{
			var time = TimeMethod(RunMapper);
			Times.Add(new KeyValuePair<string, long>(_customMapper.MapperName, time));

			ValidateData(_mapTo);
		}

		private void DoTheCalculationsForManualMapper()
		{
			var time = TimeMethod(RunManual);
			Times.Add(new KeyValuePair<string, long>("Manual Map", time));
			ValidateData(_mapTo);
		}

		private void RunManual()
		{
			_mapTo = new List<DestinationClass>();
			foreach (var source in _mapFrom)
			{
				var result = HelperMapper.GetFrom(source);
				_mapTo.Add(result);
			}
		}

		private void RunMapper()
		{
			_mapTo = _customMapper.Map(_mapFrom);
		}

		private void ValidateData(List<DestinationClass> destination)
		{
			if(destination == null || destination.Count == 0)
			{
				throw new Exception("value not filled");
			}

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

		public void ValidateData()
		{
			if (_mapFrom == null || _mapFrom.Count == 0)
			{
				throw new Exception("value not filled");
			}

			if (_mapFrom[1].SourceClassId != 2)
			{
				throw new Exception("SourceClass.SourceClassId value not filled");
			}

			if (string.IsNullOrEmpty(_mapFrom[0].FirstName))
			{
				throw new Exception("SourceClass.FirstName value not filled");
			}

			if (string.IsNullOrEmpty(_mapFrom[0].LastName))
			{
				throw new Exception("SourceClass.LastName value not filled");
			}

			if (_mapFrom[0].Children == null || _mapFrom[0].Children.Count == 0)
			{
				throw new Exception("SourceClass.children not present");
			}

			if (_mapFrom[0].Children[0].SourceChildId == 0)
			{
				throw new Exception("SourceClass.children.SourceChildId not present");
			}

			if (_mapFrom[0].Children[0].SourceNephews == null || _mapFrom[0].Children[0].SourceNephews.Count == 0)
			{
				throw new Exception("SourceClass.children.SourceNephews not present");
			}

			if (string.IsNullOrEmpty(_mapFrom[0].Children[0].SourceNephews[0].FirstName))
			{
				throw new Exception("SourceClass.children.SourceNephews.FirstName not present");
			}

			if (string.IsNullOrEmpty(_mapFrom[0].Children[0].SourceNephews[0].LastName))
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
	}
}
