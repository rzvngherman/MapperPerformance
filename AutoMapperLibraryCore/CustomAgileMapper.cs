﻿using MapperPerformanceCore.Objects;

namespace AutoMapperLibrary
{
	public class CustomAgileMapper : ICustomMapper
	{
		private string _mapperName;
		public CustomAgileMapper()
		{
			_mapperName = "AgileMapper";
		}
		public string MapperName => _mapperName;

		public void CreateMap<T1, T2>()
		{
		}

		public T2 Map<T1, T2>(T1 customers)
			where T2 : class
		{
			var result = AgileObjects.AgileMapper.Mapper.Map(customers).ToANew<T2>();
			return result;
		}
	}
}