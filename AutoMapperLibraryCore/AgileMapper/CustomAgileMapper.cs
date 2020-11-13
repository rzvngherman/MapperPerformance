using AgileObjects.AgileMapper;
using AutoMapperLibraryCore.AgileMapperConverters;
using MapperPerformanceCore.Objects;
using System.Collections.Generic;

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

		public List<DestinationClass> Map(List<SourceClass> customers)
		{
			var results = AgileObjects.AgileMapper.Mapper.Map(customers).ToANew<List<DestinationClass>>();
			return results;
		}
	}
}
