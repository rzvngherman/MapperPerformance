using AutoMapperLibrary;
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

		private List<MapFrom> _mapFrom;

		public Test2Helper()
		{
			//Setup
			_automapper = AutomapperConfiguration_CreateMapper();
			_boilerplateMapper = BoxedMapping_CreateMapper();
			_tinymapper = TinyMapperConfiguration_CreateMapper();
			_agileMapper = AgileMapperConfiguration_CreateMapper();
			_mapsterMapper = MapsterMapperConfiguration_CreateMapper();
		}

		internal void PopulateData(int x)
		{
			var random = new Random();
			_mapFrom = new List<MapFrom>();
			for (var i = 0; i < x; ++i)
			{
				var mf = new MapFrom()
				{
					Id = i,
					BooleanFrom = random.NextDouble() > 0.5D,
					DateTimeOffsetFrom = DateTimeOffset.UtcNow,
					IntegerFrom = random.Next(),
					LongFrom = random.Next(),
					StringFrom = random.Next().ToString(CultureInfo.InvariantCulture),
				};
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
			Console.WriteLine(string.Format("{0} (ms) - {1}", TimeMethod(Automapper), "Automapper"));
			Console.WriteLine(string.Format("{0} (ms) - {1}", TimeMethod(Tinymapper), "Tinymapper"));
			Console.WriteLine(string.Format("{0} (ms) - {1}", TimeMethod(Agilemapper), "Agilemapper"));
			Console.WriteLine(string.Format("{0} (ms) - {1}", TimeMethod(Mapstermapper), "Mapstermapper"));
			Console.WriteLine(string.Format("{0} (ms) - {1}", TimeMethod(BoxedMapping), "BoxedMapper"));
			Console.WriteLine(string.Format("{0} (ms) - Manual Map", TimeMethod(RunManual)));

			Console.WriteLine("");
		}

		private void RunManual()
		{
			var customers = new List<MapTo>();
			foreach (var source in _mapFrom)
			{
				MapTo customerViewItem = new MapTo()
				{
					Id = source.Id,
					BooleanTo = source.BooleanFrom,
					DateTimeOffsetTo = source.DateTimeOffsetFrom,
					IntegerTo = source.IntegerFrom,
					LongTo = source.LongFrom,
					StringTo = source.StringFrom
				};

				customers.Add(customerViewItem);
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
