using AgileObjects.AgileMapper;
using AutoMapperLibraryCore.AgileMapperConverters;
using MapperPerformanceCore.Objects;

namespace AutoMapperLibrary
{
	public class CustomAgileMapper : ICustomMapper
	{
		private string _mapperName;
		public CustomAgileMapper()
		{
			_mapperName = "AgileMapper";

			Mapper.WhenMapping.UseConfigurations.From<AgileConfiguration>();
		}
		public string MapperName => _mapperName;

		public DestinationClass Map<SourceClass, DestinationClass>(SourceClass customers)
			where DestinationClass : class
		{
			var result = AgileObjects.AgileMapper.Mapper.Map(customers).ToANew<DestinationClass>();
			return result;
		}

		public T2 MapGeneric<T1, T2>(T1 customers) where T2 : class
		{
			throw new System.NotImplementedException();
		}
	}
}
