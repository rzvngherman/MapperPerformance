using AutoMapperLibraryCore.Mapster;
using MapperPerformanceCore.Objects;
using Mapster;

namespace AutoMapperLibrary
{
	public class CustomMapsterMapper : ICustomMapper
	{
		private string _mapperName;
		private TypeAdapterConfig _config;

		public CustomMapsterMapper()
		{
			_mapperName = "MapsterMapper";

			_config = new TypeAdapterConfig();
			new MapsterConfig().Register(_config);
		}

		public string MapperName => _mapperName;

		public DestinationClass Map<SourceClass, DestinationClass>(SourceClass customers)
			where DestinationClass : class
		{
			var result = customers.Adapt<DestinationClass>(_config);
			return result;
		}

		public T2 MapGeneric<T1, T2>(T1 customers) where T2 : class
		{
			throw new System.NotImplementedException();
		}
	}
}
