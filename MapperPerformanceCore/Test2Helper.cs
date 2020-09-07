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

		private List<MapFrom> _mapFrom;

		public Test2Helper()
		{
			//Setup
			_automapper = AutomapperConfiguration_CreateMapper();
			_boilerplateMapper = BoxedMapping_CreateMapper();
			_tinymapper = TinyMapperConfiguration_CreateMapper();
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

		internal void DoTest(int x)
		{
			var watch = new Stopwatch();

			//1
			watch.Start();
			var t1 = _boilerplateMapper.MapList(_mapFrom);
			watch.Stop();
			Console.WriteLine(string.Format("{2} with {0} records: (miliseconds) {1}", x, watch.ElapsedMilliseconds, "BoxedMapper"));

			//2
			watch.Start();
			var t2 = _automapper.Map<List<MapTo>>(_mapFrom);
			watch.Stop();
			Console.WriteLine(string.Format("{2} with {0} records: (miliseconds) {1}", x, watch.ElapsedMilliseconds, "Automapper"));

			//3
			watch.Start();
			var t3 = _tinymapper.Map<List<MapFrom>, List<MapTo>>(_mapFrom);
			watch.Stop();
			Console.WriteLine(string.Format("{2} with {0} records: (miliseconds) {1}", x, watch.ElapsedMilliseconds, "Tinymapper"));


			Console.WriteLine("");
		}

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
	}
}
