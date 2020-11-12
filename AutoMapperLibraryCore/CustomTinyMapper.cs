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
			// https://github.com/TinyMapper/TinyMapper/wiki/Custom-mapping
			TypeDescriptor.AddAttributes(typeof(List<SourceClass>), new TypeConverterAttribute(typeof(SourceClassConverterList)));
			Nelibur.ObjectMapper.TinyMapper.Bind<List<SourceClass>, List<DestinationClass>>();

			_mapperName = "TinyMapper";
		}

		public T2 MapGeneric<T1, T2>(T1 customers) where T2 : class
		{
			throw new NotImplementedException();
		}

		public DestinationClass Map<SourceClass, DestinationClass>(SourceClass customers) where DestinationClass : class
		{
			var result = Nelibur.ObjectMapper.TinyMapper.Map<DestinationClass>(customers);
			return result;
		}
	}
}
