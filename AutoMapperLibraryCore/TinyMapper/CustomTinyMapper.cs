using AutoMapperLibraryCore.TinyMapperConverters;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoMapperLibraryCore
{
	public class CustomTinyMapper : ICustomMapper
	{
		private readonly string _mapperName;

		public string MapperName => _mapperName;

		public CustomTinyMapper()
		{
			// (TSource, TTarget) -> List<SourceClass> TO List<DestinationClass>
			TypeDescriptor.AddAttributes(typeof(List<SourceClass>), new TypeConverterAttribute(typeof(SourceClassConverterList)));
			Nelibur.ObjectMapper.TinyMapper.Bind<List<SourceClass>, List<DestinationClass>>();

			_mapperName = "TinyMapper";
		}

		public List<DestinationClass> Map(List<SourceClass> customers)
		{
			var result = Nelibur.ObjectMapper.TinyMapper.Map<List<DestinationClass>>(customers);
			return result;
		}
	}
}
