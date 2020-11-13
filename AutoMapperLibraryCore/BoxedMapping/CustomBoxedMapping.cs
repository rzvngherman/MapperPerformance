using AutoMapperLibraryCore;
using Boxed.Mapping;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;

namespace AutoMapperLibrary
{
	public class CustomBoxedMapping : ICustomMapper
	{
		private readonly string _mapperName;
		private readonly IMapper<SourceClass, DestinationClass> _mapper;

		public CustomBoxedMapping()
		{
			_mapperName = "BoxedMapper";
			_mapper = new SourceMapper();
		}

		public string MapperName => _mapperName;

		public List<DestinationClass> Map(List<SourceClass> customers)
		{
			var results = _mapper.MapList(customers);
			return results;
		}

		public T2 MapGeneric<T1, T2>(T1 customers) where T2 : class
		{
			throw new NotImplementedException();
		}

	}
}
