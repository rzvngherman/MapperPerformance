using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.TinyMapperConverters
{
	public class TinyMapperConfig : MapperPerformanceCore.Objects.ICustomMapper
	{
		private string _mapperName;

		public TinyMapperConfig()
		{
			// CreateMap
			Nelibur.ObjectMapper.TinyMapper.Bind<MapFrom, MapTo>();
			Nelibur.ObjectMapper.TinyMapper.Bind<List<MapFrom>, List<MapTo>>();
			Nelibur.ObjectMapper.TinyMapper.Bind<MapperPerformanceCore.Objects.Customer, MapperPerformanceCore.Objects.CustomerViewItem>();
			Nelibur.ObjectMapper.TinyMapper.Bind<List<MapperPerformanceCore.Objects.Customer>, List<MapperPerformanceCore.Objects.CustomerViewItem>>();

			_mapperName = "TinyMapper";
		}

		public string MapperName => _mapperName;

		public void CreateMap<T1, T2>()
		{
		}

		public T2 Map<T1, T2>(T1 customers)
			where T2 : class
		{
			var result = Nelibur.ObjectMapper.TinyMapper.Map<T2>(customers);
			return result;
		}
	}
}
