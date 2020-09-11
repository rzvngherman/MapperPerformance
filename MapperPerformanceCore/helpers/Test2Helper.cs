using AutoMapperLibrary;
using AutoMapperLibraryCore;
using Boxed.Mapping;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace MapperPerformanceCore
{
	public class Test2Helper
	{
		private AutoMapper.IMapper _automapper;
		private IMapper<Objects.test2.MapFrom, MapTo> _boilerplateMapper;
		private AutoMapperLibraryCore.TinyMapperConverters.TinyMapperConfig _tinymapper;
		private AutoMapperLibrary.CustomAgileMapper _agileMapper;
		private CustomMapsterMapper _mapsterMapper;
		public List<KeyValuePair<string, long>> _times;

		private List<MapFrom> _mapFrom;

		public Test2Helper()
		{
			//Setup
			_automapper = AutomapperConfiguration_CreateMapper();
			_boilerplateMapper = BoxedMapping_CreateMapper();
			_tinymapper = TinyMapperConfiguration_CreateMapper();
			_agileMapper = AgileMapperConfiguration_CreateMapper();
			_mapsterMapper = MapsterMapperConfiguration_CreateMapper();
			_times = new List<KeyValuePair<string, long>>();
		}

		internal void PopulateData(int x)
		{
			var random = new Random();
			_mapFrom = new List<MapFrom>();
			for (var i = 0; i < x; ++i)
			{				
				MapFrom mf = HelperMapper.GenerateTestData(i, random);
				_mapFrom.Add(mf);
			}
		}

		private void BoxedMapping()
		{
			_boilerplateMapper.MapList(_mapFrom);
		}

		private void Automapper()
		{
			_automapper.Map<List<MapTo>>(_mapFrom);
		}

		private void Tinymapper()
		{
			_tinymapper.Map<List<MapFrom>, List<MapTo>>(_mapFrom);
		}

		private void Agilemapper()
		{
			_agileMapper.Map<List<MapFrom>, List<MapTo>>(_mapFrom);
		}

		private void Mapstermapper()
		{
			_mapsterMapper.Map<List<MapFrom>, List<MapTo>>(_mapFrom);
		}

		private long TimeMethod(Action methodToTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			methodToTime();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}

		internal void DoTest(int x)
		{
			var time = TimeMethod(Automapper);
			//Console.WriteLine(string.Format("{0} (ms) - {1}", time, "Automapper"));
			_times.Add(new KeyValuePair<string, long>("Automapper", time));

			time = TimeMethod(Tinymapper);
			//Console.WriteLine(string.Format("{0} (ms) - {1}", time, "Tinymapper"));
			_times.Add(new KeyValuePair<string, long>("Tinymapper", time));

			time = TimeMethod(Agilemapper);
			//Console.WriteLine(string.Format("{0} (ms) - {1}", time, "Agilemapper"));
			_times.Add(new KeyValuePair<string, long>("Agilemapper", time));

			time = TimeMethod(Mapstermapper);
			//Console.WriteLine(string.Format("{0} (ms) - {1}", time, "Mapstermapper"));
			_times.Add(new KeyValuePair<string, long>("Mapstermapper", time));

			time = TimeMethod(BoxedMapping);
			//Console.WriteLine(string.Format("{0} (ms) - {1}", time, "BoxedMapper"));
			_times.Add(new KeyValuePair<string, long>("BoxedMapper", time));

			time = TimeMethod(RunManual);
			//Console.WriteLine(string.Format("{0} (ms) - Manual Map", time));
			_times.Add(new KeyValuePair<string, long>("Manual Map", time));
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

		#region Mapper Configurators
		private AutoMapper.IMapper AutomapperConfiguration_CreateMapper()
		{
			var config = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperLibraryCore.AutomapperConverters.AutomapperConfig());
			});

			return config.CreateMapper();
		}

		private IMapper<MapFrom, MapTo> BoxedMapping_CreateMapper()
		{
			return new AutoMapperLibraryCore.BoxedMapperConverters.MapFromToMapToMapper();
		}

		private AutoMapperLibraryCore.TinyMapperConverters.TinyMapperConfig TinyMapperConfiguration_CreateMapper()
		{
			var mapper = new AutoMapperLibraryCore.TinyMapperConverters.TinyMapperConfig();

			return mapper;
		}

		private CustomAgileMapper AgileMapperConfiguration_CreateMapper()
		{
			return new CustomAgileMapper();
		}

		private CustomMapsterMapper MapsterMapperConfiguration_CreateMapper()
		{
			return new CustomMapsterMapper();
		}

		#endregion
	}
}
