using AutoMapperLibraryCore.Mapster;
using MapperPerformanceCore.Objects;
using Mapster;
using System.Collections.Generic;

namespace AutoMapperLibrary
{
	public class CustomMapsterMapper : ICustomMapper
	{
		private readonly string _mapperName;
		private readonly TypeAdapterConfig _config;

		public CustomMapsterMapper()
		{
			_mapperName = "MapsterMapper";

			_config = new TypeAdapterConfig();
			new MapsterConfig().Register(_config);
		}

		public string MapperName => _mapperName;

		public List<DestinationClass> Map(List<SourceClass> customers)
		{
			var result = customers.Adapt<List<DestinationClass>>(_config);
			return result;
		}
	}
}
