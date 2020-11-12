using AutoMapperLibraryCore;
using Boxed.Mapping;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;

namespace AutoMapperLibrary
{
	//public class CustomBoxedMapping : ICustomMapper
	//{
	//	private string _mapperName;
	//	private IMapper<Customer, CustomerViewItem> mapperCustomer;
	//	private IMapper<MapFrom, MapTo> mapperMapFrom;

	//	public CustomBoxedMapping()
	//	{
	//		_mapperName = "BoxedMapper";
	//		mapperCustomer = new CustomerToCustomerViewItemMapper();
	//		mapperMapFrom = new MapFromToMapToMapper();
	//	}

	//	public string MapperName => _mapperName;

	//	public T2 Map<T1, T2>(T1 customers)
	//		where T2 : class
	//	{
	//		if(customers is List<Customer>)
	//		{
	//			var list = customers as List<Customer>;
	//			var result = mapperCustomer.MapList(list);
	//			return result as T2;
	//		}
	//		if(customers is List<MapFrom>)
	//		{
	//			var list = customers as List<MapFrom>;
	//			var result = mapperMapFrom.MapList(list);
	//			return result as T2;
	//		}

	//		throw new ArgumentException();
	//	}
	//}

	//public class CustomerToCustomerViewItemMapper : IMapper<Customer, CustomerViewItem>
	//{
	//	public void Map(Customer source, CustomerViewItem destination)
	//	{
	//		destination.CustomerViewItemFirstName = source.FirstName;
	//		destination.CustomerViewItemLastName = source.LastName;
	//		destination.CustomerViewItemDateOfBirth = source.DateOfBirth;
	//		destination.CustomerViewItemNumberOfOrders = source.NumberOfOrders;
	//	}
	//}

	//public class MapFromToMapToMapper : IMapper<MapFrom, MapTo>
	//{
	//	public void Map(MapFrom source, MapTo destination)
	//	{
	//		destination = HelperMapper.GetFrom(source);			
	//	}
	//}
}
