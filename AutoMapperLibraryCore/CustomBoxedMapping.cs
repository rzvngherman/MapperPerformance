using Boxed.Mapping;
using MapperPerformanceCore.Objects;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;

namespace AutoMapperLibrary
{
	public class CustomBoxedMapping : ICustomMapper
	{
		private string _mapperName;
		public CustomBoxedMapping()
		{
			_mapperName = "BoxedMapper";
		}

		public string MapperName => _mapperName;

		private IMapper<Customer, CustomerViewItem> mapper;
		public void CreateMap<T1, T2>()
		{
			mapper = new DemoMapper();
		}

		public T2 Map<T1, T2>(T1 customers)
			where T2 : class
		{
				var xxx = customers as List<Customer>;
				var result = mapper.MapList(xxx);
				return  result as T2;
		}
	}


	public class DemoMapper : IMapper<Customer, CustomerViewItem>
	{
		public void Map(Customer source, CustomerViewItem destination)
		{
			destination.FirstName = source.FirstName;
			destination.LastName = source.LastName;
			destination.DateOfBirth = source.DateOfBirth;
			destination.NumberOfOrders = source.NumberOfOrders;
		}
	}
}
